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

			if (ds.Tables.Count == 0)
				return list;

			DataTable tb = ds.Tables[0];
			foreach (DataRow row in tb.Rows)
			{
				list.Add(new ProductModel
				{
					MaSP = row["MaSP"] == DBNull.Value ? 0 : Convert.ToInt32(row["MaSP"]),
					TenSP = row["TenSP"] == DBNull.Value ? "" : row["TenSP"].ToString(),
					C_ID = row["C_ID"] == DBNull.Value ? 0 : Convert.ToInt32(row["C_ID"]),
					KichCo = row["KichCo"] == DBNull.Value ? "" : row["KichCo"].ToString(),
					MauSac = row["MauSac"] == DBNull.Value ? "" : row["MauSac"].ToString(),
					Gia = row["Gia"] == DBNull.Value ? 0 : Convert.ToDecimal(row["Gia"]),
					SoLuong = row["SoLuong"] == DBNull.Value ? 0 : Convert.ToInt32(row["SoLuong"]),
					Images = row["Images"] == DBNull.Value ? "" : row["Images"].ToString(),
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
            {
                DataTable newTable = new DataTable("Products");
                newTable.Columns.Add("MaSP", typeof(int));
                newTable.Columns.Add("TenSP", typeof(string));
                newTable.Columns.Add("C_ID", typeof(int));
                newTable.Columns.Add("KichCo", typeof(string));
                newTable.Columns.Add("MauSac", typeof(string));
                newTable.Columns.Add("Gia", typeof(decimal));
                newTable.Columns.Add("SoLuong", typeof(int));
                newTable.Columns.Add("Images", typeof(string));
                ds.Tables.Add(newTable);
            }

            DataTable tb = ds.Tables[0];

            DataRow newRow = tb.NewRow();
            // ❌ KHÔNG GÁN MaSP
            newRow["TenSP"] = pdm.TenSP ?? "";
            newRow["C_ID"] = pdm.C_ID;
            newRow["KichCo"] = pdm.KichCo ?? "";
            newRow["MauSac"] = pdm.MauSac ?? "";
            newRow["Gia"] = pdm.Gia;
            newRow["SoLuong"] = pdm.SoLuong;
            newRow["Images"] = pdm.Images ?? "";

            tb.Rows.Add(newRow);

            // ✅ GHI XML
            ds.WriteXml(xmlPath);

            // ✅ SQL INSERT + GHI NGƯỢC MaSP
            await SyncXmlToSql();

            return true;
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
					int maSP = row.Table.Columns.Contains("MaSP") &&
							   row["MaSP"] != DBNull.Value
							   ? Convert.ToInt32(row["MaSP"])
							   : 0;

					if (maSP <= 0)
					{
						// ===== INSERT =====
						string insertSql = @"
            INSERT INTO Products (TenSP, C_ID, KichCo, MauSac, Gia, SoLuong, Images)
            VALUES (@TenSP, @C_ID, @KichCo, @MauSac, @Gia, @SoLuong, @Images);
            SELECT SCOPE_IDENTITY();";

						SqlCommand cmd = new SqlCommand(insertSql, conn);

						cmd.Parameters.AddWithValue("@TenSP", row["TenSP"] ?? "");
						cmd.Parameters.AddWithValue("@C_ID", row["C_ID"] ?? 0);
						cmd.Parameters.AddWithValue("@KichCo", row["KichCo"] ?? "");
						cmd.Parameters.AddWithValue("@MauSac", row["MauSac"] ?? "");
						cmd.Parameters.AddWithValue("@Gia", row["Gia"] ?? 0);
						cmd.Parameters.AddWithValue("@SoLuong", row["SoLuong"] ?? 0);
						cmd.Parameters.AddWithValue("@Images", row["Images"] ?? "");

						int newId = Convert.ToInt32(await cmd.ExecuteScalarAsync());

						// 🔥 GHI NGƯỢC MaSP VỀ XML
						if (!tb.Columns.Contains("MaSP"))
							tb.Columns.Add("MaSP", typeof(int));

						row["MaSP"] = newId;
					}
					else
					{
						// ===== UPDATE =====
						string updateSql = @"
            UPDATE Products
            SET TenSP=@TenSP,
                C_ID=@C_ID,
                KichCo=@KichCo,
                MauSac=@MauSac,
                Gia=@Gia,
                SoLuong=@SoLuong,
                Images=@Images
            WHERE MaSP=@MaSP";

						SqlCommand cmd = new SqlCommand(updateSql, conn);

						cmd.Parameters.AddWithValue("@MaSP", maSP);
						cmd.Parameters.AddWithValue("@TenSP", row["TenSP"] ?? "");
						cmd.Parameters.AddWithValue("@C_ID", row["C_ID"] ?? 0);
						cmd.Parameters.AddWithValue("@KichCo", row["KichCo"] ?? "");
						cmd.Parameters.AddWithValue("@MauSac", row["MauSac"] ?? "");
						cmd.Parameters.AddWithValue("@Gia", row["Gia"] ?? 0);
						cmd.Parameters.AddWithValue("@SoLuong", row["SoLuong"] ?? 0);
						cmd.Parameters.AddWithValue("@Images", row["Images"] ?? "");

						await cmd.ExecuteNonQueryAsync();
					}
				}

				// Sau vòng foreach → ghi XML lại
				ds.WriteXml(xmlPath);
				return true;

			}
		}
	}
}
