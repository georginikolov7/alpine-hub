using AlpineHub.Core.ViewModels.Pass;
using AlpineHub.Core.ViewModels.PassAgeGroup;
using AlpineHub.Core.ViewModels.PassPeriod;

namespace AlpineHub.Core.Contracts.Pass
{
    public interface IManageablePassService
    {
        Task<IEnumerable<AllPassesManageViewModel>> GetAllPassesAsync();
        Task AddPassAsync(AddPassFormModel model);
        Task<EditPassFormModel> GetPassForEditAsync(string? id);
        Task EditPassAsync(EditPassFormModel model);
        Task<DeletePassViewModel> GetPassForDeleteAsync(string? id);
        Task DeletePassAsync(DeletePassViewModel model);

        Task<IEnumerable<PeriodListViewModel>> GetAllPeriodsListAsync();
        Task<IEnumerable<AgeGroupListViewModel>> GetAllAgeGroupsListAsync();
    }
}
