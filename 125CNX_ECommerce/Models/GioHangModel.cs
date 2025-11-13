using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _125CNX_ECommerce.Models
{
	public class GioHangModel
	{
		[Key]
		public int GioHangID { get; set; }

		public int U_ID { get; set; }
		[ForeignKey("U_ID")]
		public UsersModel User { get; set; }

		public int MaSP { get; set; }
		[ForeignKey("MaSP")]
		public ProductModel Product { get; set; }

		public int SoLuong { get; set; }
		public DateTime NgayThem { get; set; }
	}
}
