using _125CNX_ECommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _125CNX_ECommerce.Repository
{
    public class DataContext : IdentityDbContext<AppUserModel>
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<RolesModel> Roles { get; set; }
		public DbSet<CategoriesModel> Categories { get; set; }
		public DbSet<UsersModel> Users { get; set; }
		public DbSet<ProductModel> Products { get; set; }
		public DbSet<WishlistModel> Wishlist { get; set; }
		public DbSet<GioHangModel> GioHang { get; set; }
		public DbSet<DonHangModel> DonHang { get; set; }
		public DbSet<ChiTietDonHangModel> ChiTietDonHang { get; set; }
		public DbSet<HoaDonModel> HoaDon { get; set; }
		public DbSet<ChiTietHoaDonModel> ChiTietHoaDon { get; set; }
		public DbSet<ThanhToanModel> ThanhToan { get; set; }
	}
}
