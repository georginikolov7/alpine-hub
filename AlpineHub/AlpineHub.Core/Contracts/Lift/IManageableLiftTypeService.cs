using AlpineHub.Core.ViewModels.LiftType;

namespace AlpineHub.Core.Contracts.Lift
{
    public interface IManageableLiftTypeService
    {
        Task<IEnumerable<DeleteLiftTypeViewModel>?> GetAllLiftTypesAsync();
        Task AddLiftTypeAsync(AddLiftTypeFormModel model);
        Task<EditLiftTypeFormModel> GetLiftTypeForEditAsync(string? id);
        Task EditLiftTypeAsync(EditLiftTypeFormModel model);
        Task<DeleteLiftTypeViewModel> GetLiftTypeForDeleteAsync(string? id);
        Task DeleteLiftTypeAsync(DeleteLiftTypeViewModel model);
    }
}
