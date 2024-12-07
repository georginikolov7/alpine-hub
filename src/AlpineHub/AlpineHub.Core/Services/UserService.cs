
namespace AlpineHub.Core.Services
{
    using Microsoft.AspNetCore.Identity;

    using AlpineHub.Core.Contracts;
    using AlpineHub.Core.ViewModels.User;
    using AlpineHub.Data.Models;
    using AlpineHub.Data.Contracts;
    using Microsoft.EntityFrameworkCore;

    using static AlpineHub.Common.ApplicationConstants;
    using static AlpineHub.Common.ErrorMessages;
    using static AlpineHub.Common.Formats;
    using Microsoft.Extensions.Configuration;

    public class UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager, IManagerService managerService, IConfiguration config, IRepo repo) : BaseService(repo), IUserService
    {
        public async Task ConfirmDeleteUser(DeleteUserViewModel model)
        {
            var user = await GetUserById(model.Id) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, nameof(ApplicationUser), model.Id));

            if (await userManager.IsInRoleAsync(user, AdminRoleName))
            {
                throw new ArgumentException(CannotDeleteAdmin);
            }
            await userManager.DeleteAsync(user);
        }

        public async Task<DeleteUserViewModel> DeleteUser(string userId)
        {
            var user = await GetUserById(userId) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, nameof(ApplicationUser), userId));

            return new DeleteUserViewModel()
            {
                Id = user.Id.ToString(),
                Name = user.FirstName + " " + user.LastName,
            };
        }

        public async Task<IEnumerable<string?>> GetAllAsignedRoles(string? userId)
        {
            var user = await GetUserById(userId) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, nameof(ApplicationUser), userId));

            IList<string> roles = await userManager.GetRolesAsync(user);

            if (await managerService.IsUserManager(userId))
            {
                roles.Add(nameof(ResortManager));
            }
            return roles;
        }

        public async Task<IEnumerable<string?>> GetAllAssignableRolesAsync(string? userId)
        {
            ApplicationUser? user = await GetUserById(userId) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, nameof(ApplicationUser), userId));
            var userRoles = await userManager.GetRolesAsync(user);
            List<string?> roles = await roleManager
                .Roles
                .Where(r => !userRoles.Contains(r.Name!))
                .Select(r => r.Name)
                .ToListAsync();

            if (!await managerService.IsUserManager(userId))
            {
                roles.Add(nameof(ResortManager));
            }

            return roles;
        }

        public async Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync()
        {
            IEnumerable<AllUsersViewModel> users = await userManager.Users
                 .Select(u => new AllUsersViewModel()
                 {
                     Id = u.Id.ToString(),
                     FullName = u.FirstName + " " + u.LastName,
                     Email = u.Email,
                     PhoneNumber = u.PhoneNumber,
                     Birthdate = u.Birthdate.HasValue ? u.Birthdate.Value.ToString(DateTimeFormat) : string.Empty,
                     Roles = userManager.GetRolesAsync(u).Result
                 })
                 .ToListAsync();

            foreach (var user in users)
            {
                if (await managerService.IsUserManager(user.Id))
                {
                    user.Roles.Add(nameof(ResortManager));
                }
            }
            return users;
        }
        public async Task AssignRole(RoleFormModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserId) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, model.UserId));

            if (model.RoleName == nameof(ResortManager))
            {
                await managerService.MakeUserManager(user);
            }
            else
            {
                await userManager.AddToRoleAsync(user, model.RoleName);
            }
        }

        public async Task RemoveRole(RoleFormModel model)
        {
            var user = await GetUserById(model.UserId) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, nameof(ApplicationUser), model.UserId));
            if (model.RoleName == nameof(ResortManager))
            {
                await managerService.RemoveManager(user);
                return;
            }
            else
            {
                string? masterAdminUsername = config["Identity:Admin:Username"];
                if (model.RoleName == AdminRoleName && user.UserName == masterAdminUsername)
                {
                    return;
                }
                await userManager.RemoveFromRoleAsync(user, model.RoleName);
            }
        }

        private async Task<ApplicationUser?> GetUserById(string? userId)
        {
            if (!IsGuidValid(userId, out Guid guid))
            {
                return null;
            }

            ApplicationUser? user = await userManager.FindByIdAsync(userId!) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, userId));
            return user;
        }

        public async Task<bool> IsUserAdmin(string? userId)
        {
            var applicationUser = await GetUserById(userId);
            if (applicationUser is null)
            {
                return false;
            }
            return await userManager.IsInRoleAsync(applicationUser, AdminRoleName);
        }
    }
}
