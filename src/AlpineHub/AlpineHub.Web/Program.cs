
namespace AlpineHub.Web
{
    using AlpineHub.Data;
    using AlpineHub.Data.Models;
    using AlpineHub.Web.Infrastructure.Binders;
    using AlpineHub.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Identity;
    using static Common.EntityValidationConstraints;
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAppDbContext(builder.Configuration);

            builder.Services.AddAppIdentity();
            builder.Services.AddApplicationServices();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();


            builder.Services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/User/Login";
                cfg.AccessDeniedPath = "/Home/Error/401";
            });

            builder.Services.AddControllersWithViews(cfg =>
            {
                cfg.ModelBinderProviders.Insert(0, new DateTimeModelBinderProvider(DateTimeFormat));
            });
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
    }
}
