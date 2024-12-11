using AlpineHub.Core.ViewModels.Lift;
namespace AlpineHub.Core.Contracts.Lift
{
    public interface IManageableLiftService
    {
        

        Task<IEnumerable<LiftDetailsViewModel>> GetAllLiftsAsync();
        Task AddLiftAsync(AddLiftFormModel model);

        Task<EditLiftFormModel> GetLiftForEditAsync(string? id);
        Task EditLiftAsync(EditLiftFormModel model);
        Task<DeleteLiftViewModel> GetLiftForDeleteAsync(string? id);
        Task DeleteLiftAsync(DeleteLiftViewModel model);
    }
}
