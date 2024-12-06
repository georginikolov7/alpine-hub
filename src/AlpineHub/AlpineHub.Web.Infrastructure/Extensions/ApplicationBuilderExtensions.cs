
namespace AlpineHub.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    using AlpineHub.Data.Models;

    using static AlpineHub.Common.ApplicationConstants;
    using static AlpineHub.Common.ErrorMessages;
    public static class ApplicationBuilderExtensions
    {

        public static IApplicationBuilder SeedAdminAsync(this IApplicationBuilder app, string adminEmail, string adminPassword, string adminUsername)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
            var userStore = scope.ServiceProvider.GetRequiredService<IUserStore<ApplicationUser>>();
            if (roleManager is null)
            {
                throw new ArgumentNullException(nameof(roleManager), string.Format(ServiceError, typeof(RoleManager<IdentityRole<Guid>>)));
            }
            if (userManager is null)
            {
                throw new ArgumentNullException(nameof(userManager), string.Format(ServiceError, typeof(UserManager<ApplicationUser>)));
            }
            if (userStore is null)
            {
                throw new ArgumentNullException(nameof(userStore), string.Format(ServiceError, typeof(IUserStore<ApplicationUser>)));
            }

            Task.Run(async () =>
            {
                IdentityRole<Guid>? adminRole;
                if (!await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    adminRole = new IdentityRole<Guid>(AdminRoleName);
                    IdentityResult result = await roleManager.CreateAsync(adminRole);

                    if (!result.Succeeded)
                    {
                        throw new InvalidOperationException(string.Format(CannotCreateRole, AdminRoleName));
                    }
                }
                else
                {
                    adminRole = await roleManager.FindByNameAsync(AdminRoleName);
                }

                ApplicationUser? admin = await userManager.FindByNameAsync(adminUsername);
                if (admin is null)
                {
                    admin = new ApplicationUser
                    {
                        Email = adminEmail,
                        EmailConfirmed = true,
                    };
                    await userStore.SetUserNameAsync(admin, adminUsername, CancellationToken.None);

                    var result = await userManager.CreateAsync(admin, adminPassword);
                    if (!result.Succeeded)
                    {
                        throw new InvalidOperationException(string.Format(CannotCreateUser, adminUsername));
                    }
                }
                if (await userManager.IsInRoleAsync(admin, AdminRoleName))
                {
                    return app;
                }

                if (!(await userManager.AddToRoleAsync(admin, AdminRoleName)).Succeeded)
                {
                    throw new InvalidOperationException(string.Format(CannotAddUserToRole, adminUsername, AdminRoleName));
                }
                return app;
            })
                .GetAwaiter()
                .GetResult();
            return app;

        }
    }
}
