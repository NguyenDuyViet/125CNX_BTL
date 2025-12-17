using Microsoft.AspNetCore.Mvc;
using _125CNX_ECommerce.Models;
using Microsoft.Data.SqlClient;

namespace _125CNX_ECommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly string connectionString = "Data Source=localhost;Initial Catalog=SQLShopBanGiay;Integrated Security=True;Trust Server Certificate=True";

        // GET: /Product
        public IActionResult Index(string category = null, string sort = null, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var products = new List<ProductModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT p.*, c.C_Name 
                                FROM Products p 
                                INNER JOIN Categories c ON p.C_ID = c.C_ID 
                                WHERE 1=1";
                // Lọc theo danh mục
                if (!string.IsNullOrEmpty(category))
                {
                    query += " AND c.C_Name LIKE @Category";
                }

                // Lọc theo giá
                if (minPrice.HasValue)
                {
                    query += " AND p.Gia >= @MinPrice";
                }
                if (maxPrice.HasValue)
                {
                    query += " AND p.Gia <= @MaxPrice";
                }

                // Sắp xếp
                query += sort switch
                {
                    "price-asc" => " ORDER BY p.Gia ASC",
                    "price-desc" => " ORDER BY p.Gia DESC",
                    "name-asc" => " ORDER BY p.TenSP ASC",
                    "name-desc" => " ORDER BY p.TenSP DESC",
                    "newest" => " ORDER BY p.MaSP DESC",
                    _ => ""
                };

                SqlCommand cmd = new SqlCommand(query, conn);
                
                if (!string.IsNullOrEmpty(category))
                {
                    cmd.Parameters.AddWithValue("@Category", "%" + category + "%");
                }
                if (minPrice.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MinPrice", minPrice.Value);
                }
                if (maxPrice.HasValue)
                {
                    cmd.Parameters.AddWithValue("@MaxPrice", maxPrice.Value);
                }

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new ProductModel
                    {
                        MaSP = Convert.ToInt32(reader["MaSP"]),
                        TenSP = reader["TenSP"].ToString(),
                        C_ID = Convert.ToInt32(reader["C_ID"]),
                        KichCo = reader["KichCo"].ToString(),
                        MauSac = reader["MauSac"].ToString(),
                        Gia = Convert.ToDecimal(reader["Gia"]),
                        SoLuong = Convert.ToInt32(reader["SoLuong"]),
                        Images = reader["Images"].ToString(),
                        Category = new CategoriesModel
                        {
                            C_ID = Convert.ToInt32(reader["C_ID"]),
                            C_Name = reader["C_Name"].ToString()
                        }
                    });
                }
            }

            ViewBag.CurrentCategory = category;
            ViewBag.CurrentSort = sort;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            // Lấy danh sách categories
            var categories = new List<CategoriesModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Categories";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    categories.Add(new CategoriesModel
                    {
                        C_ID = Convert.ToInt32(reader["C_ID"]),
                        C_Name = reader["C_Name"].ToString()
                    });
                }
            }
            ViewBag.Categories = categories;

            return View(products);
        }

        // GET: /Product/Details/5
        public IActionResult Details(int id)
        {
            ProductModel product = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT p.*, c.C_Name 
                                FROM Products p 
                                INNER JOIN Categories c ON p.C_ID = c.C_ID 
                                WHERE p.MaSP = @MaSP";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSP", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    product = new ProductModel
                    {
                        MaSP = Convert.ToInt32(reader["MaSP"]),
                        TenSP = reader["TenSP"].ToString(),
                        C_ID = Convert.ToInt32(reader["C_ID"]),
                        KichCo = reader["KichCo"].ToString(),
                        MauSac = reader["MauSac"].ToString(),
                        Gia = Convert.ToDecimal(reader["Gia"]),
                        SoLuong = Convert.ToInt32(reader["SoLuong"]),
                        Images = reader["Images"].ToString(),
                        Category = new CategoriesModel
                        {
                            C_ID = Convert.ToInt32(reader["C_ID"]),
                            C_Name = reader["C_Name"].ToString()
                        }
                    };
                }
            }

            if (product == null)
            {
                return NotFound();
            }

            // Lấy sản phẩm liên quan (cùng danh mục)
            var relatedProducts = new List<ProductModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT TOP 4 p.*, c.C_Name 
                                FROM Products p 
                                INNER JOIN Categories c ON p.C_ID = c.C_ID 
                                WHERE p.C_ID = @C_ID AND p.MaSP != @MaSP";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@C_ID", product.C_ID);
                cmd.Parameters.AddWithValue("@MaSP", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    relatedProducts.Add(new ProductModel
                    {
                        MaSP = Convert.ToInt32(reader["MaSP"]),
                        TenSP = reader["TenSP"].ToString(),
                        C_ID = Convert.ToInt32(reader["C_ID"]),
                        KichCo = reader["KichCo"].ToString(),
                        MauSac = reader["MauSac"].ToString(),
                        Gia = Convert.ToDecimal(reader["Gia"]),
                        SoLuong = Convert.ToInt32(reader["SoLuong"]),
                        Images = reader["Images"].ToString(),
                        Category = new CategoriesModel
                        {
                            C_ID = Convert.ToInt32(reader["C_ID"]),
                            C_Name = reader["C_Name"].ToString()
                        }
                    });
                }
            }

            ViewBag.RelatedProducts = relatedProducts;

            return View(product);
        }

        // GET: /Product/Search
        public IActionResult Search(string keyword)
        {
            var products = new List<ProductModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT p.*, c.C_Name 
                                FROM Products p 
                                INNER JOIN Categories c ON p.C_ID = c.C_ID 
                                WHERE p.TenSP LIKE @Keyword 
                                   OR p.MauSac LIKE @Keyword 
                                   OR c.C_Name LIKE @Keyword";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Keyword", "%" + (keyword ?? "") + "%");

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new ProductModel
                    {
                        MaSP = Convert.ToInt32(reader["MaSP"]),
                        TenSP = reader["TenSP"].ToString(),
                        C_ID = Convert.ToInt32(reader["C_ID"]),
                        KichCo = reader["KichCo"].ToString(),
                        MauSac = reader["MauSac"].ToString(),
                        Gia = Convert.ToDecimal(reader["Gia"]),
                        SoLuong = Convert.ToInt32(reader["SoLuong"]),
                        Images = reader["Images"].ToString(),
                        Category = new CategoriesModel
                        {
                            C_ID = Convert.ToInt32(reader["C_ID"]),
                            C_Name = reader["C_Name"].ToString()
                        }
                    });
                }
            }
            ViewBag.Keyword = keyword;
            ViewBag.ResultCount = products.Count;

            return View(products);
        }
    }
}
