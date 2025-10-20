using _125CNX_ECommerce.Models;
using _125CNX_ECommerce.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace _125CNX_ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/User")]
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly DataContext _dataContext;
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
		private void AddIdentityError(IdentityResult identityResult) //Hàm để hiển thị lỗi
		{
			foreach (var error in identityResult.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}
		}
	}
 }

