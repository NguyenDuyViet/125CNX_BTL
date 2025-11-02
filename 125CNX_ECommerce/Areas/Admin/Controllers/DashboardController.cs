using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _125CNX_ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    //[Authorize(Roles = ("Admin/Author"))]
    public class DashboardController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
