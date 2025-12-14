using _125CNX_ECommerce.Models;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;

namespace ShoeShop.DAO
{
	class ProductDao
	{
		private string GetXmlPath(string fileName)
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\App_Data\", fileName);
			return Path.GetFullPath(path);
		}
		public async Task<List<ProductModel>> GetAllProduct()
		{
			List<ProductModel> list = new List<ProductModel>();

			string xmlPath = GetXmlPath("Products.xml");
			if (!File.Exists(xmlPath))
				return list;

			DataSet ds = new DataSet();
			ds.ReadXml(xmlPath);

			DataTable tb = ds.Tables[0];
			foreach (DataRow row in tb.Rows)
			{
				list.Add(new ProductModel
				{
					MaSP = Convert.ToInt32(row["MaSP"]),
					TenSP = row["TenSP"].ToString(),
					C_ID = Convert.ToInt32(row["C_ID"]),
					KichCo = row["KichCo"].ToString(),
					MauSac = row["MauSac"].ToString(),
					Gia = Convert.ToDecimal(row["Gia"]),
					SoLuong = Convert.ToInt32(row["SoLuong"]),
					Images = row["Images"].ToString(),
				});
			}

			return list;
		}

		public async Task<bool> AddProduct(ProductModel pdm)
		{
			string xmlPath = GetXmlPath("Products.xml");
			DataSet ds = new DataSet();

			if (File.Exists(xmlPath))
				ds.ReadXml(xmlPath);
			else
				ds.Tables.Add("Products"); // nếu chưa có file

			DataTable tb = ds.Tables[0];

			// Tạo dòng mới
			DataRow newRow = tb.NewRow();
			newRow["TenSP"] = pdm.TenSP;
			newRow["C_ID"] = pdm.C_ID;
			newRow["KichCo"] = pdm.KichCo;
			newRow["MauSac"] = pdm.MauSac;
			newRow["Gia"] = pdm.Gia;
			newRow["SoLuong"] = pdm.SoLuong;
			newRow["Images"] = pdm.Images;

			tb.Rows.Add(newRow);

			// Ghi lại XML
			ds.WriteXml(xmlPath);

			return await SyncXmlToSql();
		}

		public async Task<bool> DeleteProduct(int maSP)
		{
			string xmlPath = GetXmlPath("Products.xml");

			if (!File.Exists(xmlPath))
				return false;

			// ===== 1. XOÁ TRONG XML =====
			DataSet ds = new DataSet();
			ds.ReadXml(xmlPath);
			DataTable tb = ds.Tables[0];

			DataRow row = tb.AsEnumerable()
				.FirstOrDefault(r =>
					r["MaSP"] != DBNull.Value &&
					Convert.ToInt32(r["MaSP"]) == maSP);

			if (row == null)
				return false;

			tb.Rows.Remove(row);
			ds.WriteXml(xmlPath);

			// ===== 2. ĐỒNG BỘ XOÁ SQL =====
			using (SqlConnection conn = new CSDBConnection().Connection())
			{
				await conn.OpenAsync();

				string deleteSql = "DELETE FROM Products WHERE MaSP = @MaSP";
				SqlCommand cmd = new SqlCommand(deleteSql, conn);
				cmd.Parameters.AddWithValue("@MaSP", maSP);

				await cmd.ExecuteNonQueryAsync();
			}

			return true;
		}

		public async Task<bool> UpdateProduct(ProductModel pdm)
		{
			string xmlPath = GetXmlPath("Products.xml");
			if (!File.Exists(xmlPath))
				return false;

			DataSet ds = new DataSet();
			ds.ReadXml(xmlPath);

			DataTable tb = ds.Tables[0];

			DataRow row = tb.AsEnumerable()
				.FirstOrDefault(r => Convert.ToInt32(r["MaSP"]) == pdm.MaSP);

			if (row != null)
			{
				row["TenSP"] = pdm.TenSP;
				row["C_ID"] = pdm.C_ID;
				row["KichCo"] = pdm.KichCo;
				row["MauSac"] = pdm.MauSac;
				row["Gia"] = pdm.Gia;
				row["SoLuong"] = pdm.SoLuong;
				row["Images"] = pdm.Images;

				ds.WriteXml(xmlPath);
				return await SyncXmlToSql();
			}

			return false;
		}
		public async Task<List<CategoriesModel>> GetAllCategories()
		{
			List<CategoriesModel> list = new List<CategoriesModel>();

			string xmlPath = GetXmlPath("Categories.xml");
			if (!File.Exists(xmlPath))
				return list;

			DataSet ds = new DataSet();
			ds.ReadXml(xmlPath);

			DataTable tb = ds.Tables[0];
			foreach (DataRow row in tb.Rows)
			{
				list.Add(new CategoriesModel
				{
					C_ID = Convert.ToInt32(row["C_ID"]),
					C_Name = row["C_Name"].ToString()
				});
			}

			return list;
		}

		public async Task<bool> SyncXmlToSql()
		{
			string xmlPath = GetXmlPath("Products.xml");

			if (!File.Exists(xmlPath))
			{
				return false;
			}

			// 1) Đọc XML
			DataSet ds = new DataSet();
			ds.ReadXml(xmlPath);
			DataTable tb = ds.Tables[0];

			using (SqlConnection conn = new CSDBConnection().Connection())
			{
				await conn.OpenAsync();

				foreach (DataRow row in tb.Rows)
				{
					// ===== FIX 1: Không được Convert null =====
					int masp = row["MaSP"] == DBNull.Value || string.IsNullOrWhiteSpace(row["MaSP"].ToString())
						? 0
						: Convert.ToInt32(row["MaSP"]);

					// 2) Kiểm tra masp tồn tại trong SQL chưa
					string checkQuery = "SELECT COUNT(*) FROM Products WHERE MaSP = @MaSP";
					SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
					checkCmd.Parameters.AddWithValue("@MaSP", masp);

					int count = Convert.ToInt32(await checkCmd.ExecuteScalarAsync());

					if (count == 0)
					{
						// 3) INSERT mới
						string insertQuery = @"
							INSERT INTO Products (TenSP, C_ID, KichCo, MauSac, Gia, SoLuong, Images) 
                                VALUES (@TenSP, @C_ID, @KichCo, @MauSac, @Gia, @SoLuong, @Images)";

						SqlCommand cmd = new SqlCommand(insertQuery, conn);

						cmd.Parameters.AddWithValue("@TenSP", row["TenSP"]);
						cmd.Parameters.AddWithValue("@C_ID", row["C_ID"]);
						cmd.Parameters.AddWithValue("@KichCo", row["KichCo"]);
						cmd.Parameters.AddWithValue("@MauSac", row["MauSac"]);
						cmd.Parameters.AddWithValue("@Gia", row["Gia"]);
						cmd.Parameters.AddWithValue("@SoLuong", row["SoLuong"]);
						cmd.Parameters.AddWithValue("@Images", row["Images"]);

						await cmd.ExecuteNonQueryAsync();
					}
					else
					{
						// 4) UPDATE
						string updateQuery = @"
											UPDATE Products
											SET TenSP = @TenSP,
												C_ID = @C_ID,
												KichCo = @KichCo,
												MauSac = @MauSac,
												Gia = @Gia,
												SoLuong = @SoLuong,
												Images = @Images
											WHERE MaSP = @MaSP";

						SqlCommand cmd = new SqlCommand(updateQuery, conn);

						cmd.Parameters.AddWithValue("@MaSP", row["MaSP"]);
						cmd.Parameters.AddWithValue("@TenSP", row["TenSP"]);
						cmd.Parameters.AddWithValue("@C_ID", row["C_ID"]);
						cmd.Parameters.AddWithValue("@KichCo", row["KichCo"]);
						cmd.Parameters.AddWithValue("@MauSac", row["MauSac"]);
						cmd.Parameters.AddWithValue("@Gia", row["Gia"]);
						cmd.Parameters.AddWithValue("@SoLuong", row["SoLuong"]);
						cmd.Parameters.AddWithValue("@Images", row["Images"]);

						await cmd.ExecuteNonQueryAsync();
					}
				}
			}
			return true;
		}
	}
}
