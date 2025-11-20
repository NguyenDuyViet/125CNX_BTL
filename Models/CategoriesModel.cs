using System.ComponentModel.DataAnnotations;

namespace _125CNX_ECommerce.Models
{
	public class CategoriesModel
	{
		[Key]
		public int C_ID { set; get; }
		public string C_Name { set; get; }
	}
}
