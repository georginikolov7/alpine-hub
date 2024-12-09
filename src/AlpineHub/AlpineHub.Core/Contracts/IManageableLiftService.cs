using AlpineHub.Core.ViewModels.Lift;
using AlpineHub.Core.ViewModels.LiftType;

namespace AlpineHub.Core.Contracts
{
    public interface IManageableLiftService
    {
        Task<IEnumerable<DeleteLiftTypeViewModel>?> GetAllLiftTypesAsync();
        Task AddLiftTypeAsync(AddLiftTypeFormModel model);
        Task<EditLiftTypeFormModel> GetLiftTypeForEditAsync(string? id);
        Task EditLiftTypeAsync(EditLiftTypeFormModel model);
        Task<DeleteLiftTypeViewModel> GetLiftTypeForDeleteAsync(string? id);
        Task DeleteLiftTypeAsync(DeleteLiftTypeViewModel model);

        Task<IEnumerable<LiftDetailsViewModel>> GetAllLiftsAsync();
        Task AddLiftAsync(AddLiftFormModel model);

        Task<EditLiftFormModel> GetLiftForEditAsync(string? id);
        Task EditLiftAsync(EditLiftFormModel model);
        Task<DeleteLiftViewModel> GetLiftForDeleteAsync(string? id);
        Task DeleteLiftAsync(DeleteLiftViewModel model);
    }
}
