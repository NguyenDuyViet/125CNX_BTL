using Microsoft.AspNetCore.Identity;

namespace _125CNX_ECommerce.Models
{
    public class AppUserModel : IdentityUser
    {
        public string Occupayion {  get; set; }
        public string RoleId { get; set; }
		public string Token { get; set; }
	}
}
