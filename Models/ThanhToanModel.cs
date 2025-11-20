using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _125CNX_ECommerce.Models
{
	public class ThanhToanModel
	{
		[Key]
		public int MaTT { get; set; }

		public int MaHD { get; set; }
		[ForeignKey("MaHD")]
		public HoaDonModel HoaDon { get; set; }

		public string PhuongThuc { get; set; }
		public decimal SoTien { get; set; }
		public DateTime NgayTT { get; set; }
		public string TrangThai { get; set; }
	}
}
