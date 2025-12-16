using _125CNX_ECommerce.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Data.SqlClient;

namespace ShoeShop.DAO
{
	class UserDao
	{
		private string GetXmlPath(string fileName)
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\App_Data\", fileName);
			return Path.GetFullPath(path);
		}

		public async Task<UsersModel> CheckLogin(string username, string password)
		{
			// Lấy đường dẫn App_Data trong project
			string xmlPath = GetXmlPath("Users.xml");

			if (!File.Exists(xmlPath))
			{
				return null;
			}

			// Load XML vào DataSet
			DataSet ds = new DataSet();
			ds.ReadXml(xmlPath);

			if (ds.Tables.Count == 0)
			{
				return null;
			}

			DataTable table = ds.Tables[0];

			// Tìm user hợp lệ
			DataRow found = table.AsEnumerable().FirstOrDefault(row =>
							row["TenDangNhap"].ToString() == username &&
							row["MatKhau"].ToString() == password);

			if (found != null)
			{
				return new UsersModel
				{
					U_ID = Convert.ToInt32(found["U_ID"]),
					HoTen = found["HoTen"].ToString(),
					DiaChi = found["DiaChi"].ToString(),
					SDT = found["SDT"].ToString(),
					Email = found["Email"].ToString(),
					RoleID = Convert.ToInt32(found["RoleID"]),
					TenDangNhap = found["TenDangNhap"].ToString(),
					MatKhau = found["MatKhau"].ToString(),
					ChucVu = found["ChucVu"].ToString()
				};
			}

			return null;
		}

		public async Task<List<UsersModel>> GetAllUser()
		{
			List<UsersModel> list = new List<UsersModel>();

			string xmlPath = GetXmlPath("Users.xml");
			if (!File.Exists(xmlPath))
				return list;

			DataSet ds = new DataSet();
			ds.ReadXml(xmlPath);

			DataTable tb = ds.Tables[0];
			foreach (DataRow row in tb.Rows)
			{
				list.Add(new UsersModel
				{
					U_ID = Convert.ToInt32(row["U_ID"]),
					HoTen = row["HoTen"].ToString(),
					DiaChi = row["DiaChi"].ToString(),
					SDT = row["SDT"].ToString(),
					Email = row["Email"].ToString(),
					RoleID = Convert.ToInt32(row["RoleID"]),
					TenDangNhap = row["TenDangNhap"].ToString(),
					MatKhau = row["MatKhau"].ToString(),
					ChucVu = row["ChucVu"].ToString()
				});
			}

			return list;
		}

		internal async Task<bool> AddUser(UsersModel us)
		{
			string xmlPath = GetXmlPath("Users.xml");
			DataSet ds = new DataSet();

			if (File.Exists(xmlPath))
				ds.ReadXml(xmlPath);
			else
				ds.Tables.Add("Users"); // nếu chưa có file

			DataTable tb = ds.Tables[0];

			// Tạo dòng mới
			DataRow newRow = tb.NewRow();
			newRow["HoTen"] = us.HoTen;
			newRow["DiaChi"] = us.DiaChi;
			newRow["SDT"] = us.SDT;
			newRow["Email"] = us.Email;
			newRow["RoleID"] = us.RoleID;
			newRow["TenDangNhap"] = us.TenDangNhap;
			newRow["MatKhau"] = us.MatKhau;
			newRow["ChucVu"] = us.ChucVu;

			tb.Rows.Add(newRow);

			// Ghi lại XML
			ds.WriteXml(xmlPath);

			return await SyncXmlToSql();
		}

		internal async Task<bool> DeleteUser(int UID)
		{
			string xmlPath = GetXmlPath("Users.xml");

			if (!File.Exists(xmlPath))
				return false;

			// ===== 1. XOÁ TRONG XML =====
			DataSet ds = new DataSet();
			ds.ReadXml(xmlPath);
			DataTable tb = ds.Tables[0];

			DataRow row = tb.AsEnumerable()
				.FirstOrDefault(r =>
					r["U_ID"] != DBNull.Value &&
					Convert.ToInt32(r["U_ID"]) == UID);

			if (row == null)
				return false;

			tb.Rows.Remove(row);
			ds.WriteXml(xmlPath);

			// ===== 2. ĐỒNG BỘ XOÁ SQL =====
			using (SqlConnection conn = new CSDBConnection().Connection())
			{
				await conn.OpenAsync();

				string deleteSql = "DELETE FROM Users WHERE U_ID = @ID";
				SqlCommand cmd = new SqlCommand(deleteSql, conn);
				cmd.Parameters.AddWithValue("@ID", UID);

				await cmd.ExecuteNonQueryAsync();
			}

			return true;
		}

		internal async Task<bool> UpdateUser(UsersModel us)
		{
			string xmlPath = GetXmlPath("Users.xml");
			if (!File.Exists(xmlPath))
				return false;

			DataSet ds = new DataSet();
			ds.ReadXml(xmlPath);

			DataTable tb = ds.Tables[0];

			DataRow row = tb.AsEnumerable()
				.FirstOrDefault(r => Convert.ToInt32(r["U_ID"]) == us.U_ID);

			if (row != null)
			{
				row["HoTen"] = us.HoTen;
				row["DiaChi"] = us.DiaChi;
				row["SDT"] = us.SDT;
				row["Email"] = us.Email;
				row["RoleID"] = us.RoleID;
				row["TenDangNhap"] = us.TenDangNhap;
				row["MatKhau"] = us.MatKhau;
				row["ChucVu"] = us.ChucVu;

				ds.WriteXml(xmlPath);
				return await SyncXmlToSql();
			}

			return false;
		}

		public async Task XmlExporter(string tableName)
		{
			using (CSDBConnection db = new CSDBConnection())
			using (SqlConnection conn = db.Connection())
			{
				await conn.OpenAsync();

				using (SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM {tableName}", conn))
				{
					DataSet ds = new DataSet();
					da.Fill(ds, tableName);

					// 🔥 Lấy đường dẫn App_Data trong project
					string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\App_Data");
					if (!Directory.Exists(folder))
						Directory.CreateDirectory(folder);

					string filePath = Path.Combine(folder, $"{tableName}.xml");

					// 🔥 Kiểm tra tồn tại → xóa file cũ
					if (File.Exists(filePath))
					{
						// Giải phóng file nếu đang bị open bởi ai đó → tránh IOException
						GC.Collect();
						GC.WaitForPendingFinalizers();

						File.Delete(filePath);
					}

					// Xuất XML mới
					ds.WriteXml(filePath);
				}
			}
		}

		public async Task<bool> SyncXmlToSql()
		{
			string xmlPath = GetXmlPath("Users.xml");
			if (!File.Exists(xmlPath)) return false;

			DataSet ds = new DataSet();
			ds.ReadXml(xmlPath);
			DataTable tb = ds.Tables[0];

			using (SqlConnection conn = new CSDBConnection().Connection())
			{
				await conn.OpenAsync();

				foreach (DataRow row in tb.Rows)
				{
					int uid = row.Table.Columns.Contains("U_ID") &&
							  row["U_ID"] != DBNull.Value
							  ? Convert.ToInt32(row["U_ID"])
							  : 0;

					if (uid <= 0)
					{
						// ===== INSERT =====
						string insertSql = @"
                INSERT INTO Users (HoTen, DiaChi, SDT, Email, RoleID, TenDangNhap, MatKhau, ChucVu)
                VALUES (@HoTen, @DiaChi, @SDT, @Email, @RoleID, @TenDangNhap, @MatKhau, @ChucVu);
                SELECT SCOPE_IDENTITY();";

						SqlCommand cmd = new SqlCommand(insertSql, conn);

						cmd.Parameters.AddWithValue("@HoTen", row["HoTen"] ?? "");
						cmd.Parameters.AddWithValue("@DiaChi", row["DiaChi"] ?? "");
						cmd.Parameters.AddWithValue("@SDT", row["SDT"] ?? "");
						cmd.Parameters.AddWithValue("@Email", row["Email"] ?? "");
						cmd.Parameters.AddWithValue("@RoleID", row["RoleID"] ?? 0);
						cmd.Parameters.AddWithValue("@TenDangNhap", row["TenDangNhap"] ?? "");
						cmd.Parameters.AddWithValue("@MatKhau", row["MatKhau"] ?? "");
						cmd.Parameters.AddWithValue("@ChucVu", row["ChucVu"] ?? "");

						int newId = Convert.ToInt32(await cmd.ExecuteScalarAsync());

						// 🔥 GHI NGƯỢC ID VỀ XML
						if (!tb.Columns.Contains("U_ID"))
							tb.Columns.Add("U_ID", typeof(int));

						row["U_ID"] = newId;
					}
					else
					{
						// ===== UPDATE =====
						string updateSql = @"
                UPDATE Users SET
                    HoTen=@HoTen,
                    DiaChi=@DiaChi,
                    SDT=@SDT,
                    Email=@Email,
                    RoleID=@RoleID,
                    TenDangNhap=@TenDangNhap,
                    MatKhau=@MatKhau,
                    ChucVu=@ChucVu
                WHERE U_ID=@U_ID";

						SqlCommand cmd = new SqlCommand(updateSql, conn);

						cmd.Parameters.AddWithValue("@U_ID", uid);
						cmd.Parameters.AddWithValue("@HoTen", row["HoTen"] ?? "");
						cmd.Parameters.AddWithValue("@DiaChi", row["DiaChi"] ?? "");
						cmd.Parameters.AddWithValue("@SDT", row["SDT"] ?? "");
						cmd.Parameters.AddWithValue("@Email", row["Email"] ?? "");
						cmd.Parameters.AddWithValue("@RoleID", row["RoleID"] ?? 0);
						cmd.Parameters.AddWithValue("@TenDangNhap", row["TenDangNhap"] ?? "");
						cmd.Parameters.AddWithValue("@MatKhau", row["MatKhau"] ?? "");
						cmd.Parameters.AddWithValue("@ChucVu", row["ChucVu"] ?? "");

						await cmd.ExecuteNonQueryAsync();
					}
				}

				// GHI XML SAU KHI ĐỒNG BỘ
				ds.WriteXml(xmlPath);
				return true;
			}
		}

	}
}
