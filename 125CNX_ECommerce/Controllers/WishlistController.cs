using Microsoft.AspNetCore.Mvc;
using _125CNX_ECommerce.Models;
using Microsoft.Data.SqlClient;

namespace _125CNX_ECommerce.Controllers
{
    public class WishlistController : Controller
    {
        private readonly string connectionString = "Data Source=localhost;Initial Catalog=SQLShopBanGiay;Integrated Security=True;Trust Server Certificate=True";

        // GET: /Wishlist
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("U_ID");
            
            // Debug: Log user ID
            Console.WriteLine($"Wishlist Index - User ID: {userId}");
            
            if (userId == null)
            {
                TempData["Error"] = "Vui lòng đăng nhập để xem danh sách yêu thích";
                return RedirectToAction("Index", "Home");
            }

            var wishlistItems = new List<WishlistModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT w.YeuThichID, w.U_ID, w.MaSP, w.NgayYeuThich,
                                p.TenSP, p.Gia, p.Images, p.SoLuong, p.C_ID, p.KichCo, p.MauSac,
                                c.C_Name
                                FROM Wishlist w
                                INNER JOIN Products p ON w.MaSP = p.MaSP
                                INNER JOIN Categories c ON p.C_ID = c.C_ID
                                WHERE w.U_ID = @U_ID
                                ORDER BY w.NgayYeuThich DESC";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@U_ID", userId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    wishlistItems.Add(new WishlistModel
                    {
                        YeuThichID = Convert.ToInt32(reader["YeuThichID"]),
                        U_ID = Convert.ToInt32(reader["U_ID"]),
                        MaSP = Convert.ToInt32(reader["MaSP"]),
                        NgayYeuThich = Convert.ToDateTime(reader["NgayYeuThich"]),
                        Product = new ProductModel
                        {
                            MaSP = Convert.ToInt32(reader["MaSP"]),
                            TenSP = reader["TenSP"].ToString(),
                            Gia = Convert.ToDecimal(reader["Gia"]),
                            Images = reader["Images"].ToString(),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            C_ID = Convert.ToInt32(reader["C_ID"]),
                            KichCo = reader["KichCo"].ToString(),
                            MauSac = reader["MauSac"].ToString(),
                            Category = new CategoriesModel
                            {
                                C_Name = reader["C_Name"].ToString()
                            }
                        }
                    });
                }
            }

            return View(wishlistItems);
        }

        // POST: /Wishlist/Add
        [HttpPost]
        public IActionResult Add(int productId)
        {
            var userId = HttpContext.Session.GetInt32("U_ID");
            
            if (userId == null)
            {
                return Json(new { success = false, message = "Vui lòng đăng nhập" });
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra đã có trong wishlist chưa
                    string checkQuery = "SELECT COUNT(*) FROM Wishlist WHERE U_ID = @U_ID AND MaSP = @MaSP";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@U_ID", userId);
                    checkCmd.Parameters.AddWithValue("@MaSP", productId);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        return Json(new { success = false, message = "Sản phẩm đã có trong danh sách yêu thích" });
                    }

                    // Thêm vào wishlist
                    string insertQuery = "INSERT INTO Wishlist (U_ID, MaSP, NgayYeuThich) VALUES (@U_ID, @MaSP, @NgayYeuThich)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@U_ID", userId);
                    insertCmd.Parameters.AddWithValue("@MaSP", productId);
                    insertCmd.Parameters.AddWithValue("@NgayYeuThich", DateTime.Now);
                    insertCmd.ExecuteNonQuery();

                    return Json(new { success = true, message = "Đã thêm vào danh sách yêu thích" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Lỗi: {ex.Message}" });
            }
        }

        // POST: /Wishlist/Remove
        [HttpPost]
        public IActionResult Remove([FromBody] WishlistRemoveRequest request)
        {
            var userId = HttpContext.Session.GetInt32("U_ID");
            
            Console.WriteLine($"Remove called - UserId: {userId}, WishlistId: {request?.wishlistId}");
            
            if (userId == null)
            {
                return Json(new { success = false, message = "Vui lòng đăng nhập" });
            }

            if (request == null || request.wishlistId <= 0)
            {
                return Json(new { success = false, message = "WishlistId không hợp lệ" });
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Wishlist WHERE YeuThichID = @YeuThichID AND U_ID = @U_ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@YeuThichID", request.wishlistId);
                    cmd.Parameters.AddWithValue("@U_ID", userId);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();

                    Console.WriteLine($"Delete result: {result} rows affected");

                    if (result > 0)
                    {
                        return Json(new { success = true, message = "Đã xóa khỏi danh sách yêu thích" });
                    }
                    else
                    {
                        return Json(new { success = false, message = "Không tìm thấy sản phẩm (có thể đã bị xóa hoặc không thuộc về bạn)" });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Remove error: {ex.Message}");
                return Json(new { success = false, message = $"Lỗi: {ex.Message}" });
            }
        }

        // POST: /Wishlist/Toggle - Thêm hoặc xóa
        [HttpPost]
        public IActionResult Toggle([FromBody] WishlistToggleRequest request)
        {
            var userId = HttpContext.Session.GetInt32("U_ID");
            
            Console.WriteLine($"Toggle called - UserId: {userId}, ProductId: {request?.productId}");
            
            if (userId == null)
            {
                return Json(new { success = false, message = "Vui lòng đăng nhập", requireLogin = true });
            }

            if (request == null || request.productId <= 0)
            {
                return Json(new { success = false, message = "ProductId không hợp lệ" });
            }

            int productId = request.productId;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra sản phẩm có tồn tại không
                    string checkProductQuery = "SELECT COUNT(*) FROM Products WHERE MaSP = @MaSP";
                    SqlCommand checkProductCmd = new SqlCommand(checkProductQuery, conn);
                    checkProductCmd.Parameters.AddWithValue("@MaSP", productId);
                    int productExists = Convert.ToInt32(checkProductCmd.ExecuteScalar());

                    Console.WriteLine($"Product check - MaSP: {productId}, Exists: {productExists}");

                    if (productExists == 0)
                    {
                        return Json(new { success = false, message = $"Sản phẩm không tồn tại (MaSP: {productId})" });
                    }

                    // Kiểm tra đã có trong wishlist chưa
                    string checkQuery = "SELECT YeuThichID FROM Wishlist WHERE U_ID = @U_ID AND MaSP = @MaSP";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@U_ID", userId);
                    checkCmd.Parameters.AddWithValue("@MaSP", productId);

                    var wishlistId = checkCmd.ExecuteScalar();

                    if (wishlistId != null)
                    {
                        // Đã có -> Xóa
                        string deleteQuery = "DELETE FROM Wishlist WHERE YeuThichID = @YeuThichID";
                        SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                        deleteCmd.Parameters.AddWithValue("@YeuThichID", wishlistId);
                        deleteCmd.ExecuteNonQuery();

                        return Json(new { success = true, action = "removed", message = "Đã xóa khỏi yêu thích" });
                    }
                    else
                    {
                        // Chưa có -> Thêm
                        string insertQuery = "INSERT INTO Wishlist (U_ID, MaSP, NgayYeuThich) VALUES (@U_ID, @MaSP, GETDATE())";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@U_ID", userId);
                        insertCmd.Parameters.AddWithValue("@MaSP", productId);
                        insertCmd.ExecuteNonQuery();

                        return Json(new { success = true, action = "added", message = "Đã thêm vào yêu thích" });
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log chi tiết lỗi SQL
                return Json(new { success = false, message = $"Lỗi SQL: {ex.Message}", errorNumber = ex.Number });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Lỗi: {ex.Message}" });
            }
        }
    }

    // Request model for Toggle action
    public class WishlistToggleRequest
    {
        public int productId { get; set; }
    }

    // Request model for Remove action
    public class WishlistRemoveRequest
    {
        public int wishlistId { get; set; }
    }
}
