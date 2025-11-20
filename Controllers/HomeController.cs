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
    // private readonly DataContext _dataContext; // Commented out - using XML instead
    // private readonly UserManager<AppUserModel> _userManager; // Commented out - requires database

    public HomeController(ILogger<HomeController> logger) // Removed DataContext and UserManager
    {
        _logger = logger;
        // _dataContext = context;
        // _userManager = userManager;
    }

    public IActionResult Index()
    {
		var appDataPath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");

		// COMMENTED OUT: Only export from SQL to XML if database is connected
		// var convertService = new ConvertSQLtoXML(_dataContext);
		// convertService.ExportAllTablesAsXml(appDataPath);

		// Read directly from XML file
		string pathFile = Path.Combine(appDataPath, "Products.xml");
		var products = new List<ProductModel>();

		if (System.IO.File.Exists(pathFile))
		{
			XDocument doc = XDocument.Load(pathFile);
			products = doc.Descendants("ProductModel")
				.Select(x => new ProductModel
				{
					MaSP = (int)x.Element("MaSP"),
					TenSP = (string)x.Element("TenSP"),
					C_ID = (int)x.Element("C_ID"),
					KichCo = (string)x.Element("KichCo"),
					MauSac = (string)x.Element("MauSac"),
					Gia = (decimal)x.Element("Gia"),
					SoLuong = (int)x.Element("SoLuong"),
					Images = (string)x.Element("Images"),

					Category = new CategoriesModel
					{
						C_ID = (int)x.Element("Category").Element("C_ID"),
						C_Name = (string)x.Element("Category").Element("C_Name")
					}
				}).ToList();
		}

		ViewData["Shoeshop"] = "Official Store";
        return View(products);
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
