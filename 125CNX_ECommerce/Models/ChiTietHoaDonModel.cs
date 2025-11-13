using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _125CNX_ECommerce.Models
{
	public class ChiTietHoaDonModel
	{
		[Key]
		public int MaCTHD { get; set; }

		public int MaHD { get; set; }
		[ForeignKey("MaHD")]
		public HoaDonModel HoaDon { get; set; }

		public int MaSP { get; set; }
		[ForeignKey("MaSP")]
		public ProductModel Product { get; set; }

		public int SoLuong { get; set; }
		public decimal DonGia { get; set; }
	}
}
