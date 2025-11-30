using Microsoft.AspNetCore.Mvc;
using _125CNX_ECommerce.Models;
using _125CNX_ECommerce.Repository;
using _125CNX_ECommerce.Service;
using System.Xml.Linq;

namespace _125CNX_ECommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _dataContext;

        public ProductController(DataContext context)
        {
            _dataContext = context;
        }

        // GET: /Product
        public IActionResult Index(string category = null, string sort = null, decimal? minPrice = null, decimal? maxPrice = null)
        {

            return View();
        }

        // GET: /Product/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: /Product/Search
        public IActionResult Search(string keyword)
        {
            return View();
        }
    }
}
