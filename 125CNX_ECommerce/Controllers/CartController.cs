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
            return View();
        }

        // POST: /Cart/AddToCart
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
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
