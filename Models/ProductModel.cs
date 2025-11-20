using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace _125CNX_ECommerce.Models
{
	public class ProductModel
	{
		[Key]
		public int MaSP { get; set; }
		public string TenSP { get; set; }

		public int C_ID { get; set; }
		[ForeignKey("C_ID")]
		public CategoriesModel Category { get; set; }

		public string KichCo { get; set; }
		public string MauSac { get; set; }
		public decimal Gia { get; set; }
		public int SoLuong { get; set; }
		public string Images { get; set; }
	}
}
