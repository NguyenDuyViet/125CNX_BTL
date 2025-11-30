using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _125CNX_ECommerce.Models;
using _125CNX_ECommerce.Repository;
using Microsoft.AspNetCore.Identity;
using _125CNX_ECommerce.Service;
using System.Xml.Linq;

namespace _125CNX_ECommerce.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DataContext _dataContext;
    private readonly UserManager<AppUserModel> _userManager; 

    public HomeController(ILogger<HomeController> logger, DataContext context, UserManager<AppUserModel> userManager)
    {
        _logger = logger;
        _dataContext = context;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
		ViewData["Shoeshop"] = "Official Store";
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Compare()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult Wishlist()
    {
        return View();
    }

    public IActionResult NotFound()
    {
        return View();
    }

   
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  
}
