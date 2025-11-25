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
            var appDataPath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");
            var convertService = new ConvertSQLtoXML(_dataContext);
            convertService.ExportAllTablesAsXml(appDataPath);

            string pathFile = Path.Combine(appDataPath, "Products.xml");
            var products = new List<ProductModel>();

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

            // Lọc theo danh mục
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category.C_Name.ToLower().Contains(category.ToLower())).ToList();
                ViewBag.CurrentCategory = category;
            }

            // Lọc theo giá
            if (minPrice.HasValue)
            {
                products = products.Where(p => p.Gia >= minPrice.Value).ToList();
            }
            if (maxPrice.HasValue)
            {
                products = products.Where(p => p.Gia <= maxPrice.Value).ToList();
            }

            // Sắp xếp
            products = sort switch
            {
                "price-asc" => products.OrderBy(p => p.Gia).ToList(),
                "price-desc" => products.OrderByDescending(p => p.Gia).ToList(),
                "name-asc" => products.OrderBy(p => p.TenSP).ToList(),
                "name-desc" => products.OrderByDescending(p => p.TenSP).ToList(),
                "newest" => products.OrderByDescending(p => p.MaSP).ToList(),
                _ => products
            };

            ViewBag.CurrentSort = sort;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            // Lấy danh sách categories
            string categoriesPath = Path.Combine(appDataPath, "Categories.xml");
            XDocument catDoc = XDocument.Load(categoriesPath);
            var categories = catDoc.Descendants("CategoriesModel")
                .Select(x => new CategoriesModel
                {
                    C_ID = (int)x.Element("C_ID"),
                    C_Name = (string)x.Element("C_Name")
                }).ToList();

            ViewBag.Categories = categories;

            return View(products);
        }

        // GET: /Product/Details/5
        public IActionResult Details(int id)
        {
            var appDataPath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");
            var convertService = new ConvertSQLtoXML(_dataContext);
            convertService.ExportAllTablesAsXml(appDataPath);

            string pathFile = Path.Combine(appDataPath, "Products.xml");

            XDocument doc = XDocument.Load(pathFile);
            var product = doc.Descendants("ProductModel")
                .Where(x => (int)x.Element("MaSP") == id)
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
                }).FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            // Lấy sản phẩm liên quan (cùng danh mục)
            var relatedProducts = doc.Descendants("ProductModel")
                .Where(x => (int)x.Element("C_ID") == product.C_ID && (int)x.Element("MaSP") != id)
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
                })
                .Take(4)
                .ToList();

            ViewBag.RelatedProducts = relatedProducts;

            return View(product);
        }

        // GET: /Product/Search
        public IActionResult Search(string keyword)
        {
            var appDataPath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");
            var convertService = new ConvertSQLtoXML(_dataContext);
            convertService.ExportAllTablesAsXml(appDataPath);

            string pathFile = Path.Combine(appDataPath, "Products.xml");

            XDocument doc = XDocument.Load(pathFile);
            var products = doc.Descendants("ProductModel")
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

            if (!string.IsNullOrEmpty(keyword))
            {
                products = products.Where(p =>
                    p.TenSP.ToLower().Contains(keyword.ToLower()) ||
                    p.MauSac.ToLower().Contains(keyword.ToLower()) ||
                    p.Category.C_Name.ToLower().Contains(keyword.ToLower())
                ).ToList();
            }

            ViewBag.Keyword = keyword;
            ViewBag.ResultCount = products.Count;

            return View(products);
        }
    }
}
