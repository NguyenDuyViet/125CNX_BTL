using Microsoft.AspNetCore.Mvc;
using _125CNX_ECommerce.Models;
using Microsoft.Data.SqlClient;

namespace _125CNX_ECommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly string connectionString = "Data Source=localhost;Initial Catalog=SQLShopBanGiay;Integrated Security=True;Trust Server Certificate=True";

        // GET: /Cart
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("U_ID");
            
            // Nếu chưa đăng nhập, yêu cầu đăng nhập
            if (userId == null)
            {
                TempData["Error"] = "Vui lòng đăng nhập để xem giỏ hàng";
                return RedirectToAction("Index", "Home");
            }

            var cartItems = new List<GioHangModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT g.GioHangID, g.U_ID, g.MaSP, g.SoLuong, g.NgayThem,
                                    p.TenSP, p.Gia, p.Images, p.SoLuong as ProductStock, p.C_ID,
                                    c.C_Name
                                    FROM GioHang g
                                    INNER JOIN Products p ON g.MaSP = p.MaSP
                                    INNER JOIN Categories c ON p.C_ID = c.C_ID
                                    WHERE g.U_ID = @U_ID
                                    ORDER BY g.NgayThem DESC";
                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@U_ID", userId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cartItems.Add(new GioHangModel
                        {
                            GioHangID = Convert.ToInt32(reader["GioHangID"]),
                            U_ID = Convert.ToInt32(reader["U_ID"]),
                            MaSP = Convert.ToInt32(reader["MaSP"]),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            NgayThem = Convert.ToDateTime(reader["NgayThem"]),
                            Product = new ProductModel
                            {
                                MaSP = Convert.ToInt32(reader["MaSP"]),
                                TenSP = reader["TenSP"].ToString(),
                                Gia = Convert.ToDecimal(reader["Gia"]),
                                Images = reader["Images"].ToString(),
                                SoLuong = Convert.ToInt32(reader["ProductStock"]),
                                C_ID = Convert.ToInt32(reader["C_ID"]),
                                Category = new CategoriesModel
                                {
                                    C_Name = reader["C_Name"].ToString()
                                }
                            }
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Lỗi khi tải giỏ hàng: {ex.Message}";
            }

            ViewBag.UserId = userId;
            return View(cartItems);
        }

        // POST: /Cart/AddToCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            var userId = HttpContext.Session.GetInt32("U_ID");
            
            // Nếu chưa đăng nhập, yêu cầu đăng nhập
            if (userId == null)
            {
                TempData["Error"] = "Vui lòng đăng nhập để thêm sản phẩm vào giỏ hàng";
                return RedirectToAction("Index", "Home");
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Kiểm tra sản phẩm đã có trong giỏ chưa
                string checkQuery = "SELECT GioHangID, SoLuong FROM GioHang WHERE U_ID = @U_ID AND MaSP = @MaSP";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@U_ID", userId);
                checkCmd.Parameters.AddWithValue("@MaSP", productId);

                var reader = checkCmd.ExecuteReader();
                
                if (reader.Read())
                {
                    // Đã có -> cập nhật số lượng
                    int cartId = Convert.ToInt32(reader["GioHangID"]);
                    int currentQty = Convert.ToInt32(reader["SoLuong"]);
                    reader.Close();

                    string updateQuery = "UPDATE GioHang SET SoLuong = @SoLuong WHERE GioHangID = @GioHangID";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@SoLuong", currentQty + quantity);
                    updateCmd.Parameters.AddWithValue("@GioHangID", cartId);
                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    reader.Close();
                    
                    // Chưa có -> thêm mới
                    string insertQuery = "INSERT INTO GioHang (U_ID, MaSP, SoLuong, NgayThem) VALUES (@U_ID, @MaSP, @SoLuong, @NgayThem)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@U_ID", userId);
                    insertCmd.Parameters.AddWithValue("@MaSP", productId);
                    insertCmd.Parameters.AddWithValue("@SoLuong", quantity);
                    insertCmd.Parameters.AddWithValue("@NgayThem", DateTime.Now);
                    insertCmd.ExecuteNonQuery();
                }
            }

            TempData["Success"] = "Đã thêm sản phẩm vào giỏ hàng";
            return RedirectToAction("Index");
        }

        // POST: /Cart/UpdateQuantity
        [HttpPost]
        public IActionResult UpdateQuantity(int cartId, int quantity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE GioHang SET SoLuong = @SoLuong WHERE GioHangID = @GioHangID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoLuong", quantity);
                cmd.Parameters.AddWithValue("@GioHangID", cartId);

                conn.Open();
                int result = cmd.ExecuteNonQuery();

                return Json(new { success = result > 0 });
            }
        }

        // POST: /Cart/Remove
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int cartId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM GioHang WHERE GioHangID = @GioHangID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@GioHangID", cartId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            TempData["Success"] = "Đã xóa sản phẩm khỏi giỏ hàng";
            return RedirectToAction("Index");
        }

        // POST: /Cart/Clear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Clear()
        {
            var userId = HttpContext.Session.GetInt32("U_ID");
            if (userId != null)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM GioHang WHERE U_ID = @U_ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@U_ID", userId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                TempData["Success"] = "Đã xóa toàn bộ giỏ hàng";
            }
            return RedirectToAction("Index");
        }

        // POST: /Cart/Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout()
        {
            var userId = HttpContext.Session.GetInt32("U_ID");
            
            if (userId == null)
            {
                TempData["Error"] = "Vui lòng đăng nhập để thanh toán";
                return RedirectToAction("Index", "Home");
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // 1. Lấy thông tin giỏ hàng
                        string getCartQuery = @"SELECT g.MaSP, g.SoLuong, p.Gia 
                                               FROM GioHang g
                                               INNER JOIN Products p ON g.MaSP = p.MaSP
                                               WHERE g.U_ID = @U_ID";
                        
                        SqlCommand getCartCmd = new SqlCommand(getCartQuery, conn, transaction);
                        getCartCmd.Parameters.AddWithValue("@U_ID", userId);

                        var cartItems = new List<(int MaSP, int SoLuong, decimal Gia)>();
                        decimal totalAmount = 0;

                        SqlDataReader reader = getCartCmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int maSP = Convert.ToInt32(reader["MaSP"]);
                            int soLuong = Convert.ToInt32(reader["SoLuong"]);
                            decimal gia = Convert.ToDecimal(reader["Gia"]);
                            
                            cartItems.Add((maSP, soLuong, gia));
                            totalAmount += gia * soLuong;
                        }
                        reader.Close();

                        if (cartItems.Count == 0)
                        {
                            transaction.Rollback();
                            TempData["Error"] = "Giỏ hàng trống!";
                            return RedirectToAction("Index");
                        }

                        // Thêm phí ship nếu < 500K
                        if (totalAmount < 500000)
                        {
                            totalAmount += 30000;
                        }

                        // 2. Tạo đơn hàng
                        string createOrderQuery = @"INSERT INTO DonHang (MaKH, NgayDat, TongTien, TrangThai) 
                                                   OUTPUT INSERTED.MaDH
                                                   VALUES (@MaKH, @NgayDat, @TongTien, @TrangThai)";
                        
                        SqlCommand createOrderCmd = new SqlCommand(createOrderQuery, conn, transaction);
                        createOrderCmd.Parameters.AddWithValue("@MaKH", userId);
                        createOrderCmd.Parameters.AddWithValue("@NgayDat", DateTime.Now);
                        createOrderCmd.Parameters.AddWithValue("@TongTien", totalAmount);
                        createOrderCmd.Parameters.AddWithValue("@TrangThai", "Chờ xác nhận");

                        int orderId = Convert.ToInt32(createOrderCmd.ExecuteScalar());

                        // 3. Tạo chi tiết đơn hàng
                        foreach (var item in cartItems)
                        {
                            string createDetailQuery = @"INSERT INTO ChiTietDonHang (MaDH, MaSP, SoLuong, DonGia) 
                                                        VALUES (@MaDH, @MaSP, @SoLuong, @DonGia)";
                            
                            SqlCommand createDetailCmd = new SqlCommand(createDetailQuery, conn, transaction);
                            createDetailCmd.Parameters.AddWithValue("@MaDH", orderId);
                            createDetailCmd.Parameters.AddWithValue("@MaSP", item.MaSP);
                            createDetailCmd.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                            createDetailCmd.Parameters.AddWithValue("@DonGia", item.Gia);
                            createDetailCmd.ExecuteNonQuery();

                            // Giảm số lượng sản phẩm trong kho
                            string updateStockQuery = "UPDATE Products SET SoLuong = SoLuong - @SoLuong WHERE MaSP = @MaSP";
                            SqlCommand updateStockCmd = new SqlCommand(updateStockQuery, conn, transaction);
                            updateStockCmd.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                            updateStockCmd.Parameters.AddWithValue("@MaSP", item.MaSP);
                            updateStockCmd.ExecuteNonQuery();
                        }

                        // 4. Xóa giỏ hàng
                        string clearCartQuery = "DELETE FROM GioHang WHERE U_ID = @U_ID";
                        SqlCommand clearCartCmd = new SqlCommand(clearCartQuery, conn, transaction);
                        clearCartCmd.Parameters.AddWithValue("@U_ID", userId);
                        clearCartCmd.ExecuteNonQuery();

                        // Commit transaction
                        transaction.Commit();

                        // Redirect đến trang thông báo thành công
                        return RedirectToAction("OrderSuccess", new { orderId = orderId });
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        TempData["Error"] = $"Lỗi khi tạo đơn hàng: {ex.Message}";
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Lỗi hệ thống: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        // GET: /Cart/OrderSuccess
        public IActionResult OrderSuccess(int orderId)
        {
            var userId = HttpContext.Session.GetInt32("U_ID");
            
            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // Lấy thông tin đơn hàng
            DonHangModel order = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT MaDH, MaKH, NgayDat, TongTien, TrangThai 
                                FROM DonHang 
                                WHERE MaDH = @MaDH AND MaKH = @MaKH";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDH", orderId);
                cmd.Parameters.AddWithValue("@MaKH", userId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    order = new DonHangModel
                    {
                        MaDH = Convert.ToInt32(reader["MaDH"]),
                        MaKH = Convert.ToInt32(reader["MaKH"]),
                        NgayDat = Convert.ToDateTime(reader["NgayDat"]),
                        TongTien = Convert.ToDecimal(reader["TongTien"]),
                        TrangThai = reader["TrangThai"].ToString()
                    };
                }
            }

            if (order == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(order);
        }

        // GET: /Cart/MyOrders
        public IActionResult MyOrders()
        {
            var userId = HttpContext.Session.GetInt32("U_ID");
            
            if (userId == null)
            {
                TempData["Error"] = "Vui lòng đăng nhập để xem đơn hàng";
                return RedirectToAction("Index", "Home");
            }

            var orders = new List<DonHangModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT MaDH, MaKH, NgayDat, TongTien, TrangThai 
                                FROM DonHang 
                                WHERE MaKH = @MaKH
                                ORDER BY NgayDat DESC";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", userId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    orders.Add(new DonHangModel
                    {
                        MaDH = Convert.ToInt32(reader["MaDH"]),
                        MaKH = Convert.ToInt32(reader["MaKH"]),
                        NgayDat = Convert.ToDateTime(reader["NgayDat"]),
                        TongTien = Convert.ToDecimal(reader["TongTien"]),
                        TrangThai = reader["TrangThai"].ToString()
                    });
                }
            }

            return View(orders);
        }
    }
}
