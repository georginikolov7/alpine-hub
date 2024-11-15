using AlpineHub.Data;
using AlpineHub.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AlpineHub.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            // builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder
                .Services.AddDefaultIdentity<IdentityUser<Guid>>(options => ConfigureIdentity(builder, options))
        .AddEntityFrameworkStores<ApplicationDbContext>();
            //builder.Services
            //.AddIdentity<ApplicationUser, IdentityRole<Guid>>(cfg =>
            //{
            //    ConfigureIdentity(builder, cfg);
            //})
            //    .AddEntityFrameworkStores<DbContext>()
            //    .AddRoles<IdentityRole<Guid>>()
            //    .AddSignInManager<SignInManager<ApplicationUser>>()
            //    .AddUserManager<UserManager<ApplicationUser>>();


            //builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //.AddRoles<IdentityRole<Guid>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();


            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }

        private static void ConfigureIdentity(WebApplicationBuilder builder, IdentityOptions cfg)
        {
            //hehe
        }
    }
}
