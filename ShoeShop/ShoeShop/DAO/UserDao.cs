using _125CNX_ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ShoeShop.DAO
{
    class UserDao
    {
        public async Task<UsersModel> CheckLogin(string username, string password)
        {
			using (SqlConnection conn = new CSDBConnection().Connection())
			{
				await conn.OpenAsync();
				string query = @"SELECT * FROM Users WHERE TenDangNhap=@u AND MatKhau=@p";

				SqlCommand cmd = new SqlCommand(query, conn);
				cmd.Parameters.AddWithValue("@u", username);
				cmd.Parameters.AddWithValue("@p", password);

				using (SqlDataReader rd = await cmd.ExecuteReaderAsync())
				{
					if (await rd.ReadAsync())
					{
						return new UsersModel
						{
							U_ID = rd.GetInt32(0),
							HoTen = rd.GetString(1),
							DiaChi = rd.GetString(2),
							SDT = rd.GetString(3),
							Email = rd.GetString(4),
							RoleID = rd.GetInt32(5),
							ChucVu = rd.GetString(6)
						};
					}
				}
			}

			return null;
		}

		public async Task<List<UsersModel>> GetAllUser()
		{
			List<UsersModel> users = new List<UsersModel>();
			CSDBConnection db = new CSDBConnection();
			SqlConnection conn = db.Connection();
			await conn.OpenAsync();
			string query = @"SELECT * FROM Users";

			SqlCommand cmd = new SqlCommand(query, conn);
			SqlDataReader reader = await cmd.ExecuteReaderAsync();

			while (await reader.ReadAsync())
			{
				users.Add(new UsersModel
				{
					U_ID = reader.GetInt32(0),
					HoTen = reader.IsDBNull(1) ? "" : reader.GetString(1),
					DiaChi = reader.IsDBNull(2) ? "" : reader.GetString(2),
					SDT = reader.IsDBNull(3) ? "" : reader.GetString(3),
					Email = reader.IsDBNull(4) ? "" : reader.GetString(4),
					RoleID = reader.GetInt32(5),
					TenDangNhap = reader.IsDBNull(6) ? "" : reader.GetString(6),
					MatKhau = reader.IsDBNull(7) ? "" : reader.GetString(7),
					ChucVu = reader.IsDBNull(8) ? " " : reader.GetString(8)
				});
			}
			await conn.CloseAsync();

			return users;
		}

		internal async Task<bool> AddUser(UsersModel us)
		{
			CSDBConnection db = new CSDBConnection();
			SqlConnection conn = db.Connection();
			await conn.OpenAsync();

			string query = @"INSERT INTO Users (HoTen, DiaChi, SDT, Email, RoleID, TenDangNhap, MatKhau, ChucVu) 
               VALUES (@HoTen, @DiaChi, @SDT, @Email, @RoleID, @TenDangNhap, @MatKhau, @ChucVu)";

			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				cmd.Parameters.AddWithValue("@HoTen", us.HoTen);
				cmd.Parameters.AddWithValue("@DiaChi", us.DiaChi);
				cmd.Parameters.AddWithValue("@SDT", us.SDT);
				cmd.Parameters.AddWithValue("@Email", us.Email);
				cmd.Parameters.AddWithValue("@RoleID", us.RoleID);
				cmd.Parameters.AddWithValue("@TenDangNhap", us.TenDangNhap);
				cmd.Parameters.AddWithValue("@MatKhau", us.MatKhau);
				cmd.Parameters.AddWithValue("@ChucVu", us.ChucVu);

				int rowsAffected = await cmd.ExecuteNonQueryAsync();
				return rowsAffected > 0;
			}
		}

		internal async Task<bool> DeleteUser(int UID)
		{
			CSDBConnection db = new CSDBConnection();
			SqlConnection conn = db.Connection();
			conn.Open();
			string query = "DELETE FROM Users WHERE U_ID = @UID";
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				cmd.Parameters.AddWithValue("@UID", UID);

				int rowsAffected = await cmd.ExecuteNonQueryAsync();

				return rowsAffected > 0;
			}
		}

		internal async Task<bool> UpdateUser(UsersModel us)
		{
			CSDBConnection db = new CSDBConnection();
			SqlConnection conn = db.Connection();
			await conn.OpenAsync();

			string query = @"
							UPDATE Users
							SET HoTen = @HoTen,
								DiaChi = @DiaChi,
								SDT = @SDT,
								Email = @Email,
								RoleID = @RoleID,
								TenDangNhap = @TenDangNhap,
								MatKhau = @MatKhau,
								ChucVu = @ChucVu
							WHERE U_ID = @UID";

			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				cmd.Parameters.AddWithValue("@UID", us.U_ID);
				cmd.Parameters.AddWithValue("@HoTen", us.HoTen);
				cmd.Parameters.AddWithValue("@DiaChi", us.DiaChi);
				cmd.Parameters.AddWithValue("@SDT", us.SDT);
				cmd.Parameters.AddWithValue("@Email", us.Email);
				cmd.Parameters.AddWithValue("@RoleID", us.RoleID);
				cmd.Parameters.AddWithValue("@TenDangNhap", us.TenDangNhap);
				cmd.Parameters.AddWithValue("@MatKhau", us.MatKhau);
				cmd.Parameters.AddWithValue("@ChucVu", us.ChucVu);

				int rowsAffected = await cmd.ExecuteNonQueryAsync();
				return rowsAffected > 0;
			}
		}
	}
}
