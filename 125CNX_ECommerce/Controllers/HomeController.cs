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
		string connectionString = "Data Source=localhost;Initial Catalog=SQLShopBanGiay;Integrated Security=True;Trust Server Certificate=True";
		var products = new List<ProductModel>();

		using (var conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
		{
			string query = @"SELECT p.*, c.C_Name 
							FROM Products p 
							INNER JOIN Categories c ON p.C_ID = c.C_ID";
			
			var cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn);
			conn.Open();
			var reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				products.Add(new ProductModel
				{
					MaSP = Convert.ToInt32(reader["MaSP"]),
					TenSP = reader["TenSP"].ToString(),
					C_ID = Convert.ToInt32(reader["C_ID"]),
					KichCo = reader["KichCo"].ToString(),
					MauSac = reader["MauSac"].ToString(),
					Gia = Convert.ToDecimal(reader["Gia"]),
					SoLuong = Convert.ToInt32(reader["SoLuong"]),
					Images = reader["Images"].ToString(),
					Category = new CategoriesModel
					{
						C_ID = Convert.ToInt32(reader["C_ID"]),
						C_Name = reader["C_Name"].ToString()
					}
				});
			}
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
