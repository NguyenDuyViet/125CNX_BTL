// using _125CNX_ECommerce.Areas.Admin.Repository;
// using _125CNX_ECommerce.Models.Momo;
// using _125CNX_ECommerce.Services.Momo;
// using _125CNX_ECommerce.Services.Vnpay;
using _125CNX_ECommerce.Models;
using _125CNX_ECommerce.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Connection db
        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectedDb"]);
        });

        // Add Identity
        builder.Services.AddIdentity<AppUserModel, IdentityRole>()
                        .AddEntityFrameworkStores<DataContext>()
                        .AddDefaultTokenProviders();

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.IsEssential = true;
        });//Set time tồn tại cookie
        builder.Services.AddSession();
      

        var app = builder.Build();
        app.UseStatusCodePagesWithRedirects("/Home/Error?statuscode={0}");

        app.UseSession();
        app.UseStaticFiles();
        
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthentication(); // Kiểm tra đăng nhập trước
        app.UseAuthorization(); // Kiểm tra quyền sau

        app.MapStaticAssets();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();


        app.Run();
    }
}