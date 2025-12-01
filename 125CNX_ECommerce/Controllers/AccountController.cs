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
		// Tìm user trong bảng Users (custom table)
		var user = _dataContext.Users
			.FirstOrDefault(u => u.TenDangNhap == TenDangNhap && u.MatKhau == MatKhau);
		
		if (user != null)
		{
			// Lưu vào session
			HttpContext.Session.SetInt32("U_ID", user.U_ID);
			HttpContext.Session.SetString("Username", user.TenDangNhap);
			HttpContext.Session.SetString("HoTen", user.HoTen ?? user.TenDangNhap);
			HttpContext.Session.SetString("Role", user.RoleID.ToString());
			
			TempData["Success"] = $"Xin chào, {user.HoTen ?? user.TenDangNhap}!";
			return RedirectToAction("Index", "Home");
		}
		
		TempData["Error"] = "Tên đăng nhập hoặc mật khẩu không đúng!";
		return RedirectToAction("Index", "Home");
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

		var user = _dataContext.Users.Find(userId);
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

		var user = _dataContext.Users.Find(userId);
		if (user == null)
		{
			return NotFound();
		}

		// Cập nhật thông tin
		user.HoTen = model.HoTen;
		user.Email = model.Email;
		user.SDT = model.SDT;
		user.DiaChi = model.DiaChi;

		// Nếu có đổi mật khẩu
		if (!string.IsNullOrEmpty(model.MatKhau))
		{
			user.MatKhau = model.MatKhau;
		}

		_dataContext.Users.Update(user);
		_dataContext.SaveChanges();

		// Cập nhật session
		HttpContext.Session.SetString("HoTen", user.HoTen ?? user.TenDangNhap);

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
