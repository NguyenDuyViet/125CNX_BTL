using Microsoft.AspNetCore.Mvc;
using _125CNX_ECommerce.Models;
using _125CNX_ECommerce.Repository;
using _125CNX_ECommerce.Service;
using System.Xml.Linq;

namespace _125CNX_ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly DataContext _dataContext;

        public ProductController(DataContext context)
        {
            _dataContext = context;
        }

        // GET: Admin/Product
        [HttpGet("")]
        public IActionResult Index()
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

            return View(products);
        }

        // GET: Admin/Product/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            var appDataPath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");
            var convertService = new ConvertSQLtoXML(_dataContext);
            convertService.ExportAllTablesAsXml(appDataPath);

            string categoriesPath = Path.Combine(appDataPath, "Categories.xml");
            XDocument catDoc = XDocument.Load(categoriesPath);
            var categories = catDoc.Descendants("CategoriesModel")
                .Select(x => new CategoriesModel
                {
                    C_ID = (int)x.Element("C_ID"),
                    C_Name = (string)x.Element("C_Name")
                }).ToList();

            ViewBag.Categories = categories;
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                // Add product to database
                _dataContext.Products.Add(model);
                _dataContext.SaveChanges();

                TempData["Success"] = "Thêm sản phẩm thành công!";
                return RedirectToAction("Index");
            }

            var appDataPath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");
            string categoriesPath = Path.Combine(appDataPath, "Categories.xml");
            XDocument catDoc = XDocument.Load(categoriesPath);
            var categories = catDoc.Descendants("CategoriesModel")
                .Select(x => new CategoriesModel
                {
                    C_ID = (int)x.Element("C_ID"),
                    C_Name = (string)x.Element("C_Name")
                }).ToList();

            ViewBag.Categories = categories;
            return View(model);
        }

        // GET: Admin/Product/Edit/5
        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var product = _dataContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            var appDataPath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");
            var convertService = new ConvertSQLtoXML(_dataContext);
            convertService.ExportAllTablesAsXml(appDataPath);

            string categoriesPath = Path.Combine(appDataPath, "Categories.xml");
            XDocument catDoc = XDocument.Load(categoriesPath);
            var categories = catDoc.Descendants("CategoriesModel")
                .Select(x => new CategoriesModel
                {
                    C_ID = (int)x.Element("C_ID"),
                    C_Name = (string)x.Element("C_Name")
                }).ToList();

            ViewBag.Categories = categories;
            return View(product);
        }

        // POST: Admin/Product/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProductModel model)
        {
            if (id != model.MaSP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _dataContext.Products.Update(model);
                _dataContext.SaveChanges();

                TempData["Success"] = "Cập nhật sản phẩm thành công!";
                return RedirectToAction("Index");
            }

            var appDataPath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");
            string categoriesPath = Path.Combine(appDataPath, "Categories.xml");
            XDocument catDoc = XDocument.Load(categoriesPath);
            var categories = catDoc.Descendants("CategoriesModel")
                .Select(x => new CategoriesModel
                {
                    C_ID = (int)x.Element("C_ID"),
                    C_Name = (string)x.Element("C_Name")
                }).ToList();

            ViewBag.Categories = categories;
            return View(model);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var product = _dataContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _dataContext.Products.Remove(product);
            _dataContext.SaveChanges();

            TempData["Success"] = "Xóa sản phẩm thành công!";
            return RedirectToAction("Index");
        }
    }
}
