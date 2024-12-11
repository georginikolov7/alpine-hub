using AlpineHub.Core.ViewModels.Admin;
using AlpineHub.Core.ViewModels.User;

namespace AlpineHub.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync();
        Task<DeleteUserViewModel> DeleteUser(string userId);
        Task ConfirmDeleteUser(DeleteUserViewModel model);
        Task<IEnumerable<string?>> GetAllAssignableRolesAsync(string? userId);
        Task<IEnumerable<string?>> GetAllAsignedRoles(string? userId);
        Task AssignRole(RoleFormModel model);
        Task RemoveRole(RoleFormModel model);
        Task<bool> IsUserAdmin(string? userId);
        Task<DashboardViewModel> GetUserCounts();
    }
}
