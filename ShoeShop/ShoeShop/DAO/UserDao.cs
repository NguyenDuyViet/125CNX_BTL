using _125CNX_ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
    }
}
