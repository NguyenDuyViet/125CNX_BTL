using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace _125CNX_ECommerce.ViewComponents
{
    public class CartCountViewComponent : ViewComponent
    {
        private readonly string connectionString = "Data Source=localhost;Initial Catalog=SQLShopBanGiay;Integrated Security=True;Trust Server Certificate=True";

        public IViewComponentResult Invoke()
        {
            var userId = HttpContext.Session.GetInt32("U_ID");
            
            if (userId == null)
            {
                return View("Default", "0");
            }

            int cartCount = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ISNULL(SUM(SoLuong), 0) FROM GioHang WHERE U_ID = @U_ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@U_ID", userId);

                conn.Open();
                cartCount = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return View("Default", cartCount.ToString());
        }
    }
}
