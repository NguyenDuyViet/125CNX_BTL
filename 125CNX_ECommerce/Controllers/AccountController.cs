using _125CNX_ECommerce.Models;
using _125CNX_ECommerce.Models.ViewModels;
using _125CNX_ECommerce.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

public class AccountController : Controller
{
	private UserManager<AppUserModel> _userManager;
	private SignInManager<AppUserModel> _signInManager;
	private readonly DataContext _dataContext;

    public AccountController(UserManager<AppUserModel> userManager, SignInManager<AppUserModel> signInManager, DataContext dataContext)
	{
		_userManager = userManager;
		_signInManager = signInManager;
		_dataContext = dataContext;
	}


	// ------------------- LOGIN -------------------
	[HttpGet]
	public IActionResult Login(string returnUrl)
	{
		return View(new LoginViewModel { ReturnURL = returnUrl });
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Login(LoginViewModel loginVM)
	{
		if (!ModelState.IsValid)
			return View(loginVM);

		var user = await _userManager.FindByNameAsync(loginVM.Username);
		if (user == null)
		{
			ModelState.AddModelError("", "Tài khoản không tồn tại.");
			return View(loginVM);
		}

		var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, isPersistent: false, lockoutOnFailure: false);
		if (result.Succeeded)
		{
			// Redirect về ReturnURL nếu hợp lệ, nếu không về Home
			if (!string.IsNullOrEmpty(loginVM.ReturnURL) && Url.IsLocalUrl(loginVM.ReturnURL))
			{
				return Redirect(loginVM.ReturnURL);
			}
			return RedirectToAction("Index", "Home");
		}

		ModelState.AddModelError("", "Username hoặc Password bị lỗi.");
		return View(loginVM);
	}
	//------------Update user-----------------
	public async Task<IActionResult> UpdateAccount()
	{
		if ((bool)!User.Identity?.IsAuthenticated)
		{
			return RedirectToAction("Login", "Account");
		}
		var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
		var userEmail = User.FindFirstValue(ClaimTypes.Email);
		//get user by user email
		var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
		if (user == null)
		{
			return NotFound();
		}
		return View(user);
	}

	[HttpPost]
	public async Task<IActionResult> UpdateInfoAccount(AppUserModel user)
	{
		var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
		//var userEmail = User.FindFirstValue(ClaimTypes.Email);
		//get user by user email
		var userById = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
		if (userById == null)
		{
			return NotFound();
		}
		else
		{
			//Hash the new pasword
			var passwordHasher = new PasswordHasher<AppUserModel>();
			var passwordHash = passwordHasher.HashPassword(userById, user.PasswordHash);
			userById.PasswordHash = passwordHash;

			_dataContext.Update(userById);
			await _dataContext.SaveChangesAsync();
			TempData["success"] = "Update Account Information Successfully";
		}
		return RedirectToAction("UpdateAccount", "Account");
	}

	// ------------------- LOGIN FROM MODAL -------------------
	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult LoginModal(string TenDangNhap, string MatKhau)
	{
		string connectionString = "Data Source=localhost;Initial Catalog=SQLShopBanGiay;Integrated Security=True;Trust Server Certificate=True";
		
		using (SqlConnection conn = new SqlConnection(connectionString))
		{
			string query = "SELECT * FROM Users WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@TenDangNhap", TenDangNhap);
			cmd.Parameters.AddWithValue("@MatKhau", MatKhau);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader();

			if (reader.Read())
			{
				// Lưu vào session
				HttpContext.Session.SetInt32("U_ID", Convert.ToInt32(reader["U_ID"]));
				HttpContext.Session.SetString("Username", reader["TenDangNhap"].ToString());
				HttpContext.Session.SetString("HoTen", reader["HoTen"]?.ToString() ?? reader["TenDangNhap"].ToString());
				HttpContext.Session.SetString("Role", reader["RoleID"].ToString());

				TempData["Success"] = $"Xin chào, {reader["HoTen"]}!";
				return RedirectToAction("Index", "Home");
			}
			else
			{
				TempData["Error"] = "Tên đăng nhập hoặc mật khẩu không đúng!";
				return RedirectToAction("Index", "Home");
			}
		}
	}

	// ------------------- PROFILE -------------------
	[HttpGet]
	public IActionResult Profile()
	{
		var userId = HttpContext.Session.GetInt32("U_ID");
		if (userId == null)
		{
			return RedirectToAction("Index", "Home");
		}

		string connectionString = "Data Source=localhost;Initial Catalog=SQLShopBanGiay;Integrated Security=True;Trust Server Certificate=True";
		UsersModel user = null;

		using (SqlConnection conn = new SqlConnection(connectionString))
		{
			string query = "SELECT * FROM Users WHERE U_ID = @U_ID";
			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@U_ID", userId);

			conn.Open();
			SqlDataReader reader = cmd.ExecuteReader();

			if (reader.Read())
			{
				user = new UsersModel
				{
					U_ID = Convert.ToInt32(reader["U_ID"]),
					TenDangNhap = reader["TenDangNhap"].ToString(),
					HoTen = reader["HoTen"]?.ToString(),
					Email = reader["Email"]?.ToString(),
					SDT = reader["SDT"]?.ToString(),
					DiaChi = reader["DiaChi"]?.ToString(),
					RoleID = Convert.ToInt32(reader["RoleID"])
				};
			}
		}

		if (user == null)
		{
			return NotFound();
		}

		return View(user);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult UpdateProfile(UsersModel model)
	{
		var userId = HttpContext.Session.GetInt32("U_ID");
		if (userId == null)
		{
			return RedirectToAction("Index", "Home");
		}

		string connectionString = "Data Source=localhost;Initial Catalog=SQLShopBanGiay;Integrated Security=True;Trust Server Certificate=True";

		using (SqlConnection conn = new SqlConnection(connectionString))
		{
			string query = "UPDATE Users SET HoTen = @HoTen, Email = @Email, SDT = @SDT, DiaChi = @DiaChi";
			
			// Nếu có đổi mật khẩu
			if (!string.IsNullOrEmpty(model.MatKhau))
			{
				query += ", MatKhau = @MatKhau";
			}
			
			query += " WHERE U_ID = @U_ID";

			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@HoTen", model.HoTen ?? (object)DBNull.Value);
			cmd.Parameters.AddWithValue("@Email", model.Email ?? (object)DBNull.Value);
			cmd.Parameters.AddWithValue("@SDT", model.SDT ?? (object)DBNull.Value);
			cmd.Parameters.AddWithValue("@DiaChi", model.DiaChi ?? (object)DBNull.Value);
			cmd.Parameters.AddWithValue("@U_ID", userId);

			if (!string.IsNullOrEmpty(model.MatKhau))
			{
				cmd.Parameters.AddWithValue("@MatKhau", model.MatKhau);
			}

			conn.Open();
			cmd.ExecuteNonQuery();
		}

		// Cập nhật session
		HttpContext.Session.SetString("HoTen", model.HoTen ?? model.TenDangNhap);

		TempData["Success"] = "Cập nhật thông tin thành công!";
		return RedirectToAction("Profile");
	}

	public IActionResult Logout()
    {
        HttpContext.Session.Clear();
		_signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

	// ------------------- Create account -------------------
	[HttpGet]
	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create(UsersModel user)
	{
		if (ModelState.IsValid)
		{
			AppUserModel newUser = new AppUserModel { UserName = user.TenDangNhap, Email = user.Email };
			IdentityResult result = await _userManager.CreateAsync(newUser, user.MatKhau);
			if (result.Succeeded)
			{
				TempData["success"] = "Tạo tài khoản thành công";
				return Redirect("/Account/Login");
			}
			foreach (IdentityError error in result.Errors)
			{
				ModelState.AddModelError("", error.Description);
			}

		}
		return View(user);
	}
}
