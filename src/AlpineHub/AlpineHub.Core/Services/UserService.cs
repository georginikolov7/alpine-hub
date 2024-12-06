
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
    public class UserService(UserManager<ApplicationUser> userManager, IRepo repo) : BaseService(repo), IUserService
    {
        public async Task ConfirmDeleteUser(DeleteUserViewModel model)
        {
            ApplicationUser? user = await userManager.FindByIdAsync(model.Id.ToString()) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, model.Id));

            if (await userManager.IsInRoleAsync(user, AdminRoleName))
            {
                throw new ArgumentException(CannotDeleteAdmin);
            }
            await userManager.DeleteAsync(user);
        }

        public async Task<DeleteUserViewModel> DeleteUser(string userId)
        {
            if (!IsGuidValid(userId, out Guid guid))
            {
                throw new ArgumentException(string.Format(InvalidId, "User", userId));
            }

            ApplicationUser? user = await userManager.FindByIdAsync(guid.ToString()) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, userId));

            return new DeleteUserViewModel()
            {
                Id = user.Id,
                Name = user.FirstName + " " + user.LastName,
            };
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

            return users;
        }


    }
}
