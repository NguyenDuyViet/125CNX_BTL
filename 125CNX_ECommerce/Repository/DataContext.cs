using _125CNX_ECommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _125CNX_ECommerce.Repository
{
    public class DataContext : IdentityDbContext<AppUserModel>
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{


		}
		// public DbSet<BrandModel> Brands { get; set; }
    }
}
