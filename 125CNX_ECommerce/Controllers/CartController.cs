using Microsoft.AspNetCore.Mvc;
using _125CNX_ECommerce.Models;
using _125CNX_ECommerce.Repository;
using _125CNX_ECommerce.Service;
using System.Xml.Linq;

namespace _125CNX_ECommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _dataContext;

        public CartController(DataContext context)
        {
            _dataContext = context;
        }

        // GET: /Cart
        public IActionResult Index()
        {
            // Lấy U_ID từ session (giả sử user đã đăng nhập)
            var userId = HttpContext.Session.GetInt32("U_ID");
            
            if (userId == null)
            {
                // Chưa đăng nhập -> chuyển đến trang login
                return RedirectToAction("Login", "Account");
            }

            var appDataPath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");
            var convertService = new ConvertSQLtoXML(_dataContext);
            convertService.ExportAllTablesAsXml(appDataPath);

            // Đọc giỏ hàng từ XML
            string cartPath = Path.Combine(appDataPath, "GioHangs.xml");
            string productPath = Path.Combine(appDataPath, "Products.xml");

            XDocument cartDoc = XDocument.Load(cartPath);
            XDocument productDoc = XDocument.Load(productPath);

            var cartItems = cartDoc.Descendants("GioHangModel")
                .Where(x => (int)x.Element("U_ID") == userId)
                .Select(x => new GioHangModel
                {
                    GioHangID = (int)x.Element("GioHangID"),
                    U_ID = (int)x.Element("U_ID"),
                    MaSP = (int)x.Element("MaSP"),
                    SoLuong = (int)x.Element("SoLuong"),
                    NgayThem = (DateTime)x.Element("NgayThem"),
                    Product = productDoc.Descendants("ProductModel")
                        .Where(p => (int)p.Element("MaSP") == (int)x.Element("MaSP"))
                        .Select(p => new ProductModel
                        {
                            MaSP = (int)p.Element("MaSP"),
                            TenSP = (string)p.Element("TenSP"),
                            Gia = (decimal)p.Element("Gia"),
                            Images = (string)p.Element("Images"),
                            SoLuong = (int)p.Element("SoLuong"),
                            Category = new CategoriesModel
                            {
                                C_ID = (int)p.Element("Category").Element("C_ID"),
                                C_Name = (string)p.Element("Category").Element("C_Name")
                            }
                        }).FirstOrDefault()
                }).ToList();

            return View(cartItems);
        }

        // POST: /Cart/AddToCart
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            var userId = HttpContext.Session.GetInt32("U_ID");
            
            // TEST: Nếu chưa đăng nhập, dùng user ID = 1 (tạm thời)
            if (userId == null)
            {
                userId = 1; // User test
                HttpContext.Session.SetInt32("U_ID", 1);
                // TempData["Error"] = "Vui lòng đăng nhập để thêm sản phẩm vào giỏ hàng";
                // return RedirectToAction("Login", "Account");
            }

            // Kiểm tra sản phẩm đã có trong giỏ chưa
            var existingItem = _dataContext.GioHang
                .FirstOrDefault(x => x.U_ID == userId && x.MaSP == productId);

            if (existingItem != null)
            {
                // Đã có -> tăng số lượng
                existingItem.SoLuong += quantity;
                _dataContext.SaveChanges();
            }
            else
            {
                // Chưa có -> thêm mới
                var cartItem = new GioHangModel
                {
                    U_ID = userId.Value,
                    MaSP = productId,
                    SoLuong = quantity,
                    NgayThem = DateTime.Now
                };
                _dataContext.GioHang.Add(cartItem);
                _dataContext.SaveChanges();
            }

            TempData["Success"] = "Đã thêm sản phẩm vào giỏ hàng";
            return RedirectToAction("Index");
        }

        // POST: /Cart/UpdateQuantity
        [HttpPost]
        public IActionResult UpdateQuantity(int cartId, int quantity)
        {
            var cartItem = _dataContext.GioHang.Find(cartId);
            if (cartItem != null)
            {
                cartItem.SoLuong = quantity;
                _dataContext.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        // POST: /Cart/Remove
        [HttpPost]
        public IActionResult Remove(int cartId)
        {
            var cartItem = _dataContext.GioHang.Find(cartId);
            if (cartItem != null)
            {
                _dataContext.GioHang.Remove(cartItem);
                _dataContext.SaveChanges();
                TempData["Success"] = "Đã xóa sản phẩm khỏi giỏ hàng";
            }
            return RedirectToAction("Index");
        }

        // POST: /Cart/Clear
        [HttpPost]
        public IActionResult Clear()
        {
            var userId = HttpContext.Session.GetInt32("U_ID");
            if (userId != null)
            {
                var cartItems = _dataContext.GioHang.Where(x => x.U_ID == userId).ToList();
                _dataContext.GioHang.RemoveRange(cartItems);
                _dataContext.SaveChanges();
                TempData["Success"] = "Đã xóa toàn bộ giỏ hàng";
            }
            return RedirectToAction("Index");
        }
    }
}
