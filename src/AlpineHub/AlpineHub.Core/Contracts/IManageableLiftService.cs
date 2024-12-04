using AlpineHub.Core.ViewModels.Lift;

namespace AlpineHub.Core.Contracts
{
    public interface IManageableLiftService
    {
        Task<IEnumerable<LiftDetailsViewModel>> GetAllManagerLiftsAsync();

        Task<EditLiftFormModel> GetLiftForEditAsync(string? id);
        Task EditLiftAsync(EditLiftFormModel model);
        Task<DeleteLiftViewModel> GetLiftForDeleteAsync(string? id);
        Task DeleteLiftAsync(DeleteLiftViewModel model);
        Task AddLiftAsync(AddLiftFormModel model);
    }
}
