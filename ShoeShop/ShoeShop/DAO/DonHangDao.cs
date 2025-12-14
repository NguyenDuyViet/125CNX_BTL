using _125CNX_ECommerce.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShoeShop.DAO
{
    class DonHangDao
    {
		private string GetXmlPath(string fileName)
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\App_Data\", fileName);
			return Path.GetFullPath(path);
		}
		public async Task<List<DonHangModel>> GetAllDonHang()
		{
			List<DonHangModel> list = new List<DonHangModel>();

			string donHangPath = GetXmlPath("DonHang.xml");
			if (!File.Exists(donHangPath))
				return list;

			DataSet dsDonHang = new DataSet();
			dsDonHang.ReadXml(donHangPath);
			DataTable tbDonHang = dsDonHang.Tables[0];

			DataTable tbUser = null;
			string UserPath = GetXmlPath("Users.xml");

			if (File.Exists(UserPath))
			{
				DataSet dsTT = new DataSet();
				dsTT.ReadXml(UserPath);
				tbUser = dsTT.Tables[0];
			}
			foreach (DataRow row in tbDonHang.Rows)
			{
				int UID = row["MaKH"] == DBNull.Value ? 0 : Convert.ToInt32(row["MaKH"]);

				// Tìm user tương ứng
				DataRow ttRow = tbUser?
					.AsEnumerable()
					.FirstOrDefault(r =>
						r["U_ID"] != DBNull.Value &&
						Convert.ToInt32(r["U_ID"]) == UID);

				list.Add(new DonHangModel
				{
					MaDH = Convert.ToInt32(row["MaDH"]),
					MaKH = Convert.ToInt32(row["MaKH"]),
					TenKhachHang = ttRow["HoTen"].ToString(),
					NgayDat = Convert.ToDateTime(row["NgayDat"]),
					TongTien = Convert.ToDecimal(row["TongTien"]),
					TrangThai = row["TrangThai"].ToString()
				});
			}

			return list;
		}

		public bool UpdateStatus(int maDH, string status)
		{
			string xmlPath = GetXmlPath("DonHang.xml");

			if (!File.Exists(xmlPath))
				return false;
			
			
			DataSet ds = new DataSet();
			ds.ReadXml(xmlPath);

			if (ds.Tables.Count == 0)
				return false;

			DataTable tb = ds.Tables[0];

			DataRow row = tb.AsEnumerable()
				.FirstOrDefault(r =>
					r["MaDH"] != DBNull.Value &&
					Convert.ToInt32(r["MaDH"]) == maDH);

			if (row == null)
				return false;

			// ===== Update trạng thái =====
			row["TrangThai"] = status;

			// ===== Ghi ngược lại XML =====
			ds.WriteXml(xmlPath, XmlWriteMode.WriteSchema);
			//Gọi hàm update vào sql
			UpdatetoSQL(maDH, status);

			return true;
		}

		public async Task<bool> UpdatetoSQL(int maDH, string status)
		{
			CSDBConnection db = new CSDBConnection();

			using (SqlConnection conn = db.Connection())
			{
				await conn.OpenAsync();

				string query = @"UPDATE DonHang SET TrangThai=@TrangThai WHERE MaDH=@MaDH";

				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@MaDH", maDH);
					cmd.Parameters.AddWithValue("@TrangThai", status);

					int rowsAffected = await cmd.ExecuteNonQueryAsync();

					return rowsAffected > 0;
				}
			}
		}

		public async Task<ChiTietDonHangModel> GetChiTietByMaDH(int maDH)
		{
			string ctPath = GetXmlPath("ChiTietDonHang.xml");
			string spPath = GetXmlPath("Products.xml");

			if (!File.Exists(ctPath))
				return null;

			//Load ChiTietDonHang.xml
			DataSet dsCT = new DataSet();
			dsCT.ReadXml(ctPath);
			DataTable tbCT = dsCT.Tables[0];

			//Load Products.xml
			DataTable tbSP = null;
			if (File.Exists(spPath))
			{
				DataSet dsSP = new DataSet();
				dsSP.ReadXml(spPath);
				tbSP = dsSP.Tables[0];
			}

			//Lấy chi tiết đầu tiên theo MaDH
			DataRow ctRow = tbCT.AsEnumerable()
				.FirstOrDefault(r =>
					r["MaDH"] != DBNull.Value &&
					Convert.ToInt32(r["MaDH"]) == maDH);

			if (ctRow == null)
				return null;

			int maSP = ctRow["MaSP"] == DBNull.Value ? 0 : Convert.ToInt32(ctRow["MaSP"]);

			//JOIN thủ công qua XML
			DataRow spRow = tbSP?
				.AsEnumerable()
				.FirstOrDefault(r =>
					r["MaSP"] != DBNull.Value &&
					Convert.ToInt32(r["MaSP"]) == maSP);

			int soLuong = ctRow["SoLuong"] == DBNull.Value ? 0 : Convert.ToInt32(ctRow["SoLuong"]);
			decimal donGia = ctRow["DonGia"] == DBNull.Value ? 0 : Convert.ToDecimal(ctRow["DonGia"]);

			return new ChiTietDonHangModel
			{
				MaCTDH = ctRow["MaCTDH"] == DBNull.Value ? 0 : Convert.ToInt32(ctRow["MaCTDH"]),
				TenSP = spRow?["TenSP"]?.ToString() ?? "",
				SoLuong = soLuong,
				DonGia = donGia,
				ThanhTien = soLuong * donGia
			};
		}

	}
}
