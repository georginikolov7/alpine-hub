using AlpineHub.Core.ViewModels.Pass;

namespace AlpineHub.Core.Contracts.Pass
{
    public interface IPassService
    {
        Task<IEnumerable<string>> GetAllAgeGroupsAsync();
        Task<IEnumerable<string>> GetAllPeriodsAsync();

        Task<AllPassesSearchFilterViewModel> GetAllPassesAsync(AllPassesSearchFilterViewModel inputModel);
    }
}
