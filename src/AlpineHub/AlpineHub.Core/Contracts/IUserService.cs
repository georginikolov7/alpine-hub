
namespace AlpineHub.Core.Contracts
{
    using AlpineHub.Core.ViewModels.User;
    public interface IUserService
    {
        Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync();
        Task<DeleteUserViewModel> DeleteUser(string userId);
        Task ConfirmDeleteUser(DeleteUserViewModel model);
    }
}
