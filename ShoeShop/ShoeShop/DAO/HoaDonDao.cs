using _125CNX_ECommerce.Models;
using System;
using System.Data.SqlClient;

namespace ShoeShop.DAO
{
	class HoaDonDao
	{
		public async Task<List<HoaDonModel>> GetAllHoaDon()
		{
			List<HoaDonModel> list = new List<HoaDonModel>();
			CSDBConnection db = new CSDBConnection();
			SqlConnection conn = db.Connection();
			await conn.OpenAsync();
			string query = @"
                    SELECT 
                        hd.MaHD,
                        hd.MaDH,
                        hd.NgayLap,
                        hd.TongTien,
                        hd.TrangThai,
                        ISNULL(tt.PhuongThuc, N'Chưa thanh toán') AS PhuongThucTT,
                        ISNULL(tt.TrangThai, N'') AS TrangThaiTT
                    FROM HoaDon hd
                    LEFT JOIN ThanhToan tt ON hd.MaHD = tt.MaHD
                    ORDER BY hd.NgayLap DESC
                ";

			SqlCommand cmd = new SqlCommand(query, conn);
			SqlDataReader reader = await cmd.ExecuteReaderAsync();

			while (await reader.ReadAsync())
			{
				list.Add(new HoaDonModel
				{
					MaHD = reader.GetInt32(0),
					MaDH = reader.GetInt32(1),
					NgayLap = reader.GetDateTime(2),
					TongTien = reader.GetDecimal(3),
					TrangThai = reader.GetString(4),
					PhuongThucTT = reader.IsDBNull(5) ? "" : reader.GetString(5),
					TrangThaiTT = reader.IsDBNull(6) ? "" : reader.GetString(6)
				});
			}
			await conn.CloseAsync();

			return list;
		}

		internal async Task<ChiTietHoaDonModel> GetChiTietByMaHD(int maHD)
		{
			CSDBConnection db = new CSDBConnection();
			ChiTietHoaDonModel chitiet = new ChiTietHoaDonModel();
			using (SqlConnection conn = db.Connection())
			{
				await conn.OpenAsync();

				string query = @"
								SELECT TOP 1 ct.MaCTHD, ct.MaHD, ct.MaSP, ct.SoLuong, ct.DonGia
								FROM ChiTietHoaDon ct
								WHERE ct.MaHD = @MaHD";

				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@MaHD", maHD);

					using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
					{
						if (await reader.ReadAsync()) // chỉ đọc hàng đầu tiên
						{
							chitiet = new ChiTietHoaDonModel
							{
								MaCTHD = reader.GetInt32(0),
								MaHD = reader.GetInt32(1),
								MaSP = reader.GetInt32(2),
								SoLuong = reader.GetInt32(3),
								DonGia = reader.GetDecimal(4)
							};
						}
					}
				}
			}

			return chitiet;
		}
	}
}
