using Microsoft.AspNetCore.Mvc;
using _125CNX_ECommerce.Repository;

namespace _125CNX_ECommerce.ViewComponents
{
    public class CartCountViewComponent : ViewComponent
    {
        private readonly DataContext _dataContext;

        public CartCountViewComponent(DataContext context)
        {
            _dataContext = context;
        }

        public IViewComponentResult Invoke()
        {
            var userId = HttpContext.Session.GetInt32("U_ID");
            
            if (userId == null)
            {
                return View("Default", "0");
            }

            var cartCount = _dataContext.GioHang
                .Where(x => x.U_ID == userId)
                .Sum(x => (int?)x.SoLuong) ?? 0;

            return View("Default", cartCount.ToString());
        }
    }
}
