
namespace AlpineHub.Web
{
    using AlpineHub.Web.AuthorizationRequirements;
    using AlpineHub.Web.Infrastructure.Binders;
    using AlpineHub.Web.Infrastructure.Extensions;
    using static Common.Formats;
    using static AlpineHub.Web.Infrastructure.Constants.CustomClaims;
    using Microsoft.AspNetCore.Mvc;

    public class Program
    {
        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);
            string adminUserName = builder.Configuration.GetValue<string>("Identity:Admin:Username")!;
            string adminEmail = builder.Configuration.GetValue<string>("Identity:Admin:Email")!;
            string adminPassword = builder.Configuration.GetValue<string>("Identity:Admin:Password")!;

            // Add services to the container.
            builder.Services.AddAppDbContext(builder.Configuration);

            builder.Services.AddAppIdentity();
            builder.Services.AddApplicationServices();
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();


            builder.Services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/Identity/Account/Login";
                cfg.AccessDeniedPath = "/Home/Error/401";
            });

            builder.Services.AddAuthorization(opt =>
            {
                opt.AddPolicy(ManagerPolicyName, policy =>
                {
                    policy.Requirements.Add(new ManagerIdRequirement());
                });
            });


            builder.Services.AddControllersWithViews(cfg =>
            {
                cfg.ModelBinderProviders.Insert(0, new DateTimeModelBinderProvider(DateTimeFormat));
                cfg.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });
            builder.Services.AddRazorPages();
            builder.Services.AddResponseCaching();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.SeedAdminAsync(adminEmail, adminPassword, adminUserName);
                app.UseDeveloperExceptionPage();
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
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");


            app.MapRazorPages();

            app.UseResponseCaching();
            app.Run();
        }
    }
}
