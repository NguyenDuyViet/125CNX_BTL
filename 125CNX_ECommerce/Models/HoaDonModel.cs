using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace _125CNX_ECommerce.Models
{
	public class HoaDonModel
	{
		[Key]
		public int MaHD { get; set; }

		public int MaDH { get; set; }
		[ForeignKey("MaDH")]
		public DonHangModel DonHang { get; set; }

		public DateTime NgayLap { get; set; }
		public decimal TongTien { get; set; }
		public string TrangThai { get; set; }
		[XmlIgnore]
		public ICollection<ChiTietHoaDonModel> ChiTietHoaDons { get; set; }
		[XmlIgnore]
		public ICollection<ThanhToanModel> ThanhToans { get; set; }
	}
}
