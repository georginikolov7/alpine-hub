
namespace AlpineHub.Core.Contracts.Slope
{
    using AlpineHub.Core.ViewModels.Slope;
    public interface IManageableSlopeService
    {
        Task<IEnumerable<SlopeDetailsViewModel>> GetAllManagerSlopesAsync();
        Task<EditSlopeFormModel> GetSlopeForEditAsync(string? id);
        Task EditSlopeAsync(EditSlopeFormModel model);
        Task<DeleteSlopeViewModel> GetSlopeForDeleteAsync(string? id);
        Task DeleteSlopeAsync(DeleteSlopeViewModel model);
        Task AddSlopeAsync(AddSlopeFormModel model);
    }
}
