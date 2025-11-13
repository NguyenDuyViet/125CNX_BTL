using _125CNX_ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

public class AccountController : Controller
{
    private readonly string connectionString = "Data Source=localhost;Initial Catalog=SQLShopBanGiay;Integrated Security=True;Trust Server Certificate=True";

    // ------------------- LOGIN -------------------
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(UserLoginModel model)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Users WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TenDangNhap", model.TenDangNhap);
            cmd.Parameters.AddWithValue("@MatKhau", model.MatKhau);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                HttpContext.Session.SetInt32("U_ID", Convert.ToInt32(reader["U_ID"]));
                HttpContext.Session.SetString("HoTen", reader["HoTen"].ToString());
                HttpContext.Session.SetString("Role", reader["RoleID"].ToString());

                TempData["Success"] = $"Xin chào, {reader["HoTen"]}!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Tên đăng nhập hoặc mật khẩu không đúng!";
                return View();
            }
        }
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }

    // ------------------- REGISTER -------------------
    [HttpGet]
    public IActionResult Register()
    {
        return View(); // view Register.cshtml
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(UserModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Users (TenDangNhap, Email, MatKhau, HoTen) VALUES (@TenDangNhap, @Email, @MatKhau, @HoTen)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TenDangNhap", model.TenDangNhap);
            cmd.Parameters.AddWithValue("@Email", model.Email);
            cmd.Parameters.AddWithValue("@MatKhau", model.MatKhau);
            cmd.Parameters.AddWithValue("@HoTen", model.HoTen ?? model.TenDangNhap);

            conn.Open();
            cmd.ExecuteNonQuery();
        }

        TempData["Success"] = "Đăng ký thành công! Hãy đăng nhập.";
        return RedirectToAction("Login");
    }
}
