using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _125CNX_ECommerce.Models
{
	public class UsersModel
	{
		[Key]
		public int U_ID { get; set; }
		public string HoTen { get; set; }
		public string DiaChi { get; set; }
		public string SDT { get; set; }
		public string Email { get; set; }
		public int RoleID { get; set; }
		public string TenDangNhap { get; set; }
		public string MatKhau { get; set; }
		public string? ChucVu { get; set; }
	}
}
