using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _125CNX_ECommerce.Models
{
	public class ChiTietDonHangModel
	{
		[Key]
		public int MaCTDH { get; set; }

		public int MaDH { get; set; }
		[ForeignKey("MaDH")]
		public DonHangModel DonHang { get; set; }

		public int MaSP { get; set; }
		[ForeignKey("MaSP")]
		public ProductModel Product { get; set; }

		public int SoLuong { get; set; }
		public decimal DonGia { get; set; }
	}
}
