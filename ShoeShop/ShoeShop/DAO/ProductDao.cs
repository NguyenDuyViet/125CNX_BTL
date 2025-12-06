using _125CNX_ECommerce.Models;
using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;

namespace ShoeShop.DAO
{
	class ProductDao
	{
		public async Task<List<ProductModel>> GetAllProduct()
		{
			List<ProductModel> list = new List<ProductModel>();
			CSDBConnection db = new CSDBConnection();
			SqlConnection conn = db.Connection();
			await conn.OpenAsync();
			string query = @"SELECT * FROM Products";

			SqlCommand cmd = new SqlCommand(query, conn);
			SqlDataReader reader = await cmd.ExecuteReaderAsync();

			while (await reader.ReadAsync())
			{
				list.Add(new ProductModel
				{
					MaSP = reader.GetInt32(0),
					TenSP = reader.IsDBNull(1) ? "" : reader.GetString(1),
					C_ID = reader.GetInt32(2),
					KichCo = reader.GetString(3),
					MauSac = reader.GetString(4),
					Gia = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5),
					SoLuong = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
					Images = reader.IsDBNull(7) ? " ": reader.GetString(7)
				});
			}
			await conn.CloseAsync();

			return list;
		}

		public async Task<bool> AddProduct(ProductModel pdm)
		{
			CSDBConnection db = new CSDBConnection();
			SqlConnection conn = db.Connection();
			conn.Open();
			string query = @"INSERT INTO Products (TenSP, C_ID, KichCo, MauSac, Gia, SoLuong, Images) 
                                VALUES (@TenSP, @C_ID, @KichCo, @MauSac, @Gia, @SoLuong, @Images)";
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				cmd.Parameters.AddWithValue("@TenSP", pdm.TenSP);
				cmd.Parameters.AddWithValue("@C_ID", pdm.C_ID);
				cmd.Parameters.AddWithValue("@KichCo", pdm.KichCo);
				cmd.Parameters.AddWithValue("@MauSac", pdm.MauSac);
				cmd.Parameters.AddWithValue("@Gia", pdm.Gia);
				cmd.Parameters.AddWithValue("@SoLuong", pdm.SoLuong);
				cmd.Parameters.AddWithValue("@Images", pdm.Images);

				int rowsAffected = await cmd.ExecuteNonQueryAsync();

				return rowsAffected > 0;
			}
		}

		public async Task<bool> DeleteProduct(int maSP)
		{
			CSDBConnection db = new CSDBConnection();
			SqlConnection conn = db.Connection();
			conn.Open();
			string query = "DELETE FROM Products WHERE MaSP = @MaSP";
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				cmd.Parameters.AddWithValue("@MaSP", maSP);

				int rowsAffected = await cmd.ExecuteNonQueryAsync();

				return rowsAffected > 0;
			}
		}

		public async Task<bool> UpdateProduct(ProductModel pdm)
		{
			CSDBConnection db = new CSDBConnection();
			SqlConnection conn = db.Connection();
			await conn.OpenAsync();

			string query = @"
							UPDATE Products
							SET TenSP = @TenSP,
								C_ID = @C_ID,
								KichCo = @KichCo,
								MauSac = @MauSac,
								Gia = @Gia,
								SoLuong = @SoLuong,
								Images = @Images
							WHERE MaSP = @MaSP";

			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				cmd.Parameters.AddWithValue("@MaSP", pdm.MaSP);
				cmd.Parameters.AddWithValue("@TenSP", pdm.TenSP);
				cmd.Parameters.AddWithValue("@C_ID", pdm.C_ID);
				cmd.Parameters.AddWithValue("@KichCo", pdm.KichCo);
				cmd.Parameters.AddWithValue("@MauSac", pdm.MauSac);
				cmd.Parameters.AddWithValue("@Gia", pdm.Gia);
				cmd.Parameters.AddWithValue("@SoLuong", pdm.SoLuong);
				cmd.Parameters.AddWithValue("@Images", pdm.Images);

				int rowsAffected = await cmd.ExecuteNonQueryAsync();
				return rowsAffected > 0;
			}
		}
		public async Task<List<CategoriesModel>> GetAllCategories()
		{
			List<CategoriesModel> list = new List<CategoriesModel>();
			CSDBConnection db = new CSDBConnection();
			SqlConnection conn = db.Connection();
			await conn.OpenAsync();
			string query = @"SELECT * FROM Categories";

			SqlCommand cmd = new SqlCommand(query, conn);
			SqlDataReader reader = await cmd.ExecuteReaderAsync();

			while (await reader.ReadAsync())
			{
				list.Add(new CategoriesModel
				{
					C_ID = reader.GetInt32(0),
					C_Name = reader.IsDBNull(1) ? "" : reader.GetString(1),
				});
			}
			await conn.CloseAsync();

			return list;
		}
	}
}
