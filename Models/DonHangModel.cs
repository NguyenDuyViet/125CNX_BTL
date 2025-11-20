using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace _125CNX_ECommerce.Models
{
	public class DonHangModel
	{
		[Key]
		public int MaDH { get; set; }

		public int MaKH { get; set; }
		[ForeignKey("MaKH")]
		public UsersModel KhachHang { get; set; }

		public DateTime NgayDat { get; set; }
		public decimal TongTien { get; set; }
		public string TrangThai { get; set; }
		[XmlIgnore]
		public ICollection<ChiTietDonHangModel> ChiTietDonHangs { get; set; }
		[XmlIgnore]
		public ICollection<HoaDonModel> HoaDons { get; set; }
	}
}