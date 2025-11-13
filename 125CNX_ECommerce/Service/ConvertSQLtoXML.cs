using _125CNX_ECommerce.Repository;
using System.Xml.Serialization;
using System.IO;
using _125CNX_ECommerce.Models;
using System.Collections.Generic;

namespace _125CNX_ECommerce.Service
{
	public class ConvertSQLtoXML
	{
		private readonly DataContext _dataContext;

		public ConvertSQLtoXML(DataContext context)
		{
			_dataContext = context;
		}

		public void ExportAllTablesAsXml(string appDataPhysicalPath)
		{
			// Tạo thư mục nếu chưa tồn tại
			if (!Directory.Exists(appDataPhysicalPath))
				Directory.CreateDirectory(appDataPhysicalPath);

			// Đọc dữ liệu từ EF Core
			var products = _dataContext.Products.ToList();
			var donhangs = _dataContext.DonHang.ToList();
			var hoadons = _dataContext.HoaDon.ToList();
			var chitietdonhangs = _dataContext.ChiTietDonHang.ToList();
			var chitiethoadons = _dataContext.ChiTietHoaDon.ToList();
			var users = _dataContext.Users.ToList();
			var categories = _dataContext.Categories.ToList();
			var giohangs = _dataContext.GioHang.ToList();
			var wishlists = _dataContext.Wishlist.ToList();
			var roles = _dataContext.Roles.ToList();
			var thanhtoans = _dataContext.ThanhToan.ToList();

			// Ghi ra từng file XML
			WriteXmlFile(products, Path.Combine(appDataPhysicalPath, "Products.xml"));
			WriteXmlFile(donhangs, Path.Combine(appDataPhysicalPath, "DonHangs.xml"));
			WriteXmlFile(hoadons, Path.Combine(appDataPhysicalPath, "HoaDons.xml"));
			WriteXmlFile(chitietdonhangs, Path.Combine(appDataPhysicalPath, "ChiTietDonHangs.xml"));
			WriteXmlFile(chitiethoadons, Path.Combine(appDataPhysicalPath, "ChiTietHoaDons.xml"));
			WriteXmlFile(users, Path.Combine(appDataPhysicalPath, "Users.xml"));
			WriteXmlFile(categories, Path.Combine(appDataPhysicalPath, "Categories.xml"));
			WriteXmlFile(giohangs, Path.Combine(appDataPhysicalPath, "GioHangs.xml"));
			WriteXmlFile(wishlists, Path.Combine(appDataPhysicalPath, "Wishlists.xml"));
			WriteXmlFile(roles, Path.Combine(appDataPhysicalPath, "Roles.xml"));
			WriteXmlFile(thanhtoans, Path.Combine(appDataPhysicalPath, "ThanhToans.xml"));
		}

		// Hàm generic để ghi file XML cho từng bảng
		private void WriteXmlFile<T>(List<T> data, string filePath)
		{
			var serializer = new XmlSerializer(typeof(List<T>));

			// Xóa file cũ nếu tồn tại
			if (File.Exists(filePath))
				File.Delete(filePath);

			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				serializer.Serialize(stream, data ?? new List<T>());
			}
		}
	}
}