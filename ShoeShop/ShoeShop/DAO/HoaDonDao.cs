using _125CNX_ECommerce.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ShoeShop.DAO
{
	class HoaDonDao
	{
		private string GetXmlPath(string fileName)
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\App_Data\", fileName);
			return Path.GetFullPath(path);
		}
		public async Task<List<HoaDonModel>> GetAllHoaDon()
		{
			List<HoaDonModel> list = new List<HoaDonModel>();

			string hoaDonPath = GetXmlPath("HoaDon.xml");
			if (!File.Exists(hoaDonPath))
				return list;

			DataSet dsHoaDon = new DataSet();
			dsHoaDon.ReadXml(hoaDonPath);
			DataTable tbHoaDon = dsHoaDon.Tables[0];

			DataTable tbThanhToan = null;
			string thanhToanPath = GetXmlPath("ThanhToan.xml");

			if (File.Exists(thanhToanPath))
			{
				DataSet dsTT = new DataSet();
				dsTT.ReadXml(thanhToanPath);
				tbThanhToan = dsTT.Tables[0];
			}

			// ===== Map dữ liệu =====
			foreach (DataRow row in tbHoaDon.Rows)
			{
				int maHD = row["MaHD"] == DBNull.Value ? 0 : Convert.ToInt32(row["MaHD"]);

				// Tìm thanh toán tương ứng
				DataRow ttRow = tbThanhToan?
					.AsEnumerable()
					.FirstOrDefault(r =>
						r["MaHD"] != DBNull.Value &&
						Convert.ToInt32(r["MaHD"]) == maHD);

				// Lấy trạng thái từ HoaDon.xml
				string trangThaiHoaDon = row["TrangThai"]?.ToString() ?? "";
				string trangThaiThanhToan = ttRow?["TrangThai"]?.ToString();
				string phuongThucTT = ttRow?["PhuongThuc"]?.ToString();

				// Logic hiển thị trạng thái thực tế:
				// 1. Nếu có ThanhToan "Hoàn tất" → HoaDon = "Đã thanh toán"
				// 2. Nếu HoaDon = "Đã thanh toán" nhưng không có ThanhToan → Hiển thị "Đã thanh toán (Chưa ghi nhận)"
				// 3. Nếu có ThanhToan nhưng không "Hoàn tất" → Hiển thị trạng thái ThanhToan
				if (!string.IsNullOrEmpty(trangThaiThanhToan))
				{
					if (trangThaiThanhToan == "Hoàn tất")
					{
						trangThaiHoaDon = "Đã thanh toán";
					}
					else
					{
						// Có record thanh toán nhưng chưa hoàn tất
						trangThaiHoaDon = $"Đang xử lý ({trangThaiThanhToan})";
					}
				}
				else if (trangThaiHoaDon == "Đã thanh toán")
				{
					// Hóa đơn đã thanh toán nhưng không có record thanh toán
					trangThaiHoaDon = "Đã thanh toán (Chưa ghi nhận)";
					trangThaiThanhToan = "Chưa ghi nhận";
				}

				list.Add(new HoaDonModel
				{
					MaHD = maHD,
					MaDH = row["MaDH"] == DBNull.Value ? 0 : Convert.ToInt32(row["MaDH"]),
					NgayLap = row["NgayLap"] == DBNull.Value
								? DateTime.MinValue
								: Convert.ToDateTime(row["NgayLap"]),
					TongTien = row["TongTien"] == DBNull.Value
								? 0
								: Convert.ToDecimal(row["TongTien"]),
					TrangThai = trangThaiHoaDon,

					//Map từ ThanhToan.xml
					PhuongThucTT = phuongThucTT,
					TrangThaiTT = trangThaiThanhToan
				});
			}

			return list;
		}


		/// <summary>
		/// Validate và fix data inconsistency giữa HoaDon và ThanhToan
		/// Logic nghiệp vụ: 
		/// - Nếu HoaDon = "Đã thanh toán" nhưng không có ThanhToan → Tạo record ThanhToan
		/// - Nếu ThanhToan = "Hoàn tất" nhưng HoaDon ≠ "Đã thanh toán" → Update HoaDon
		/// - Nếu HoaDon = "Chưa thanh toán" và có ThanhToan "Hoàn tất" → Update HoaDon
		/// </summary>
		public async Task<bool> ValidateAndFixDataConsistency()
		{
			try
			{
				string hoaDonPath = GetXmlPath("HoaDon.xml");
				string thanhToanPath = GetXmlPath("ThanhToan.xml");

				if (!File.Exists(hoaDonPath))
					return false;

				DataSet dsHoaDon = new DataSet();
				dsHoaDon.ReadXml(hoaDonPath);
				DataTable tbHoaDon = dsHoaDon.Tables[0];

				DataSet dsThanhToan = new DataSet();
				DataTable tbThanhToan = null;

				// Tạo ThanhToan.xml nếu chưa tồn tại
				if (!File.Exists(thanhToanPath))
				{
					dsThanhToan.Tables.Add("ThanhToan");
					tbThanhToan = dsThanhToan.Tables[0];
					tbThanhToan.Columns.Add("MaTT", typeof(int));
					tbThanhToan.Columns.Add("MaHD", typeof(int));
					tbThanhToan.Columns.Add("PhuongThuc", typeof(string));
					tbThanhToan.Columns.Add("SoTien", typeof(decimal));
					tbThanhToan.Columns.Add("NgayTT", typeof(DateTime));
					tbThanhToan.Columns.Add("TrangThai", typeof(string));
				}
				else
				{
					dsThanhToan.ReadXml(thanhToanPath);
					tbThanhToan = dsThanhToan.Tables[0];
				}

				bool hasHoaDonChanges = false;
				bool hasThanhToanChanges = false;
				int nextMaTT = tbThanhToan.Rows.Count > 0 ? 
					tbThanhToan.AsEnumerable().Max(r => Convert.ToInt32(r["MaTT"])) + 1 : 1;

				foreach (DataRow hoaDonRow in tbHoaDon.Rows)
				{
					int maHD = Convert.ToInt32(hoaDonRow["MaHD"]);
					string currentStatus = hoaDonRow["TrangThai"].ToString();
					decimal tongTien = Convert.ToDecimal(hoaDonRow["TongTien"]);

					// Tìm thanh toán tương ứng
					DataRow thanhToanRow = tbThanhToan.AsEnumerable()
						.FirstOrDefault(r => Convert.ToInt32(r["MaHD"]) == maHD);

					// Case 1: HoaDon = "Đã thanh toán" nhưng không có ThanhToan record
					if (currentStatus == "Đã thanh toán" && thanhToanRow == null)
					{
						// Tạo record ThanhToan mới
						DataRow newThanhToan = tbThanhToan.NewRow();
						newThanhToan["MaTT"] = nextMaTT++;
						newThanhToan["MaHD"] = maHD;
						newThanhToan["PhuongThuc"] = "Tiền mặt"; // Default
						newThanhToan["SoTien"] = tongTien;
						newThanhToan["NgayTT"] = DateTime.Now;
						newThanhToan["TrangThai"] = "Hoàn tất";
						tbThanhToan.Rows.Add(newThanhToan);
						hasThanhToanChanges = true;
					}
					// Case 2: Có ThanhToan "Hoàn tất" nhưng HoaDon không phải "Đã thanh toán"
					else if (thanhToanRow != null)
					{
						string trangThaiTT = thanhToanRow["TrangThai"].ToString();
						if (trangThaiTT == "Hoàn tất" && currentStatus != "Đã thanh toán")
						{
							hoaDonRow["TrangThai"] = "Đã thanh toán";
							hasHoaDonChanges = true;
						}
						// Case 3: HoaDon = "Chưa thanh toán" nhưng có ThanhToan không "Hoàn tất"
						else if (currentStatus == "Đã thanh toán" && trangThaiTT != "Hoàn tất")
						{
							thanhToanRow["TrangThai"] = "Hoàn tất";
							hasThanhToanChanges = true;
						}
					}
				}

				// Lưu thay đổi
				if (hasHoaDonChanges)
				{
					dsHoaDon.WriteXml(hoaDonPath);
				}

				if (hasThanhToanChanges)
				{
					dsThanhToan.WriteXml(thanhToanPath);
				}

				return true;
			}
			catch (Exception ex)
			{
				// Log error nếu cần
				return false;
			}
		}

		internal async Task<ChiTietHoaDonModel> GetChiTietByMaHD(int maHD)
		{
			string xmlPath = GetXmlPath("ChiTietHoaDon.xml");
			if (!File.Exists(xmlPath))
				return null;

			DataSet ds = new DataSet();
			ds.ReadXml(xmlPath);

			DataTable tb = ds.Tables[0];
			ChiTietHoaDonModel chitiet;

			DataRow row = tb.AsEnumerable()
				.FirstOrDefault(r => Convert.ToInt32(r["MaHD"]) == maHD);

			if (row != null)
			{
				chitiet = new ChiTietHoaDonModel
				{
					MaCTHD = Convert.ToInt32(row["MaCTHD"]),
					MaHD = Convert.ToInt32(row["MaHD"]),
					MaSP = Convert.ToInt32(row["MaSP"]),
					SoLuong = Convert.ToInt32(row["SoLuong"]),
					DonGia = Convert.ToDecimal(row["DonGia"])
				};

				ds.WriteXml(xmlPath);
				return chitiet;
			}
			return null;
		}
	}
}
