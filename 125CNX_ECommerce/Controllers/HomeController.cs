using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _125CNX_ECommerce.Models;

namespace _125CNX_ECommerce.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
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
