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
					TrangThai = row["TrangThai"]?.ToString() ?? "",

					//Map từ ThanhToan.xml
					PhuongThucTT = ttRow?["PhuongThuc"]?.ToString(),
					TrangThaiTT = ttRow?["TrangThai"]?.ToString()
				});
			}

			return list;
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
