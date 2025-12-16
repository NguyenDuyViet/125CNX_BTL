using System.ComponentModel.DataAnnotations;

namespace _125CNX_ECommerce.Models
{
	public class RolesModel
	{
		[Key]
		public int RoleID { get; set; }
		public string RoleName { get; set; }
	}
}