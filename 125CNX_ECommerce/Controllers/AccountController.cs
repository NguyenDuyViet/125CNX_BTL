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

	public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
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
