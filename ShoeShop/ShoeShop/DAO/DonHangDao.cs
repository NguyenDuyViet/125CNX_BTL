using _125CNX_ECommerce.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShoeShop.DAO
{
    class DonHangDao
    {
		public async Task<List<DonHangModel>> GetAllDonHang()
		{
			List<DonHangModel> list = new List<DonHangModel>();
			CSDBConnection db = new CSDBConnection();
			SqlConnection conn = db.Connection();
			await conn.OpenAsync();

			string query = @"
							SELECT 
								dh.MaDH, 
								dh.MaKH,
								u.HoTen AS TenKhachHang,
								dh.NgayDat, 
								dh.TongTien, 
								dh.TrangThai
							FROM DonHang dh
							LEFT JOIN Users u ON dh.MaKH = u.U_ID";
			SqlCommand cmd = new SqlCommand(query, conn);
			SqlDataReader reader = await cmd.ExecuteReaderAsync();

			while (await reader.ReadAsync())
			{
				list.Add(new DonHangModel
				{
					MaDH = reader.GetInt32(0),
					MaKH = reader.GetInt32(1),
					TenKhachHang = reader.IsDBNull(2) ? "" : reader.GetString(2),
					NgayDat = reader.GetDateTime(3),
					TongTien = reader.GetDecimal(4),
					TrangThai = reader.GetString(5)
				});
			}
			conn.CloseAsync();

			return list;
		}

		public async Task<bool> UpdateStatus(int maDH, string status)
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
			CSDBConnection db = new CSDBConnection();
			ChiTietDonHangModel chitiet = new ChiTietDonHangModel();
			using (SqlConnection conn = db.Connection())
			{
				await conn.OpenAsync();

				string query = @"
            SELECT TOP 1 ct.MaCTDH, p.TenSP, ct.SoLuong, ct.DonGia, (ct.SoLuong * ct.DonGia) as ThanhTien
            FROM ChiTietDonHang ct
            LEFT JOIN Products p ON ct.MaSP = p.MaSP
            WHERE ct.MaDH = @MaDH";

				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@MaDH", maDH);

					using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
					{
						if (await reader.ReadAsync()) // chỉ đọc hàng đầu tiên
						{
							chitiet = new ChiTietDonHangModel
							{
								MaCTDH = reader.GetInt32(0),
								TenSP = reader.IsDBNull(1) ? "" : reader.GetString(1),
								SoLuong = reader.GetInt32(2),
								DonGia = reader.GetDecimal(3),
								ThanhTien = reader.GetDecimal(4)
							};
						}
					}
				}
			}

			return chitiet;
		}
	}
}
