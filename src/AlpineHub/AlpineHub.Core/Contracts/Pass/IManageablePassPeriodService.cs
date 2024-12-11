
namespace AlpineHub.Core.Contracts.Pass
{
    using AlpineHub.Core.ViewModels.PassPeriod;
    public interface IManageablePassPeriodService
    {
        Task<IEnumerable<PeriodViewModel>> GetAllPeriods();
        Task AddPeriodAsync(AddPeriodFormModel model);
        Task<EditPeriodFormModel> GetPeriodForEditAsync(string? id);
        Task EditPeriodAsync(EditPeriodFormModel model);
        Task<DeletePeriodViewModel> GetPeriodForDeleteAsync(string? id);
        Task DeletePeriodAsync(DeletePeriodViewModel model);
    }
}
