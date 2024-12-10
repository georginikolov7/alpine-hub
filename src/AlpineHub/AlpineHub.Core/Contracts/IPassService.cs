using AlpineHub.Core.ViewModels.Pass;

namespace AlpineHub.Core.Contracts
{
    public interface IPassService
    {
        Task<IEnumerable<string>> GetAllAgeGroupsAsync();
        Task<IEnumerable<string>> GetAllPeriodsAsync();

        Task<AllPassesSearchFilterViewModel> GetAllPasses(AllPassesSearchFilterViewModel inputModel);
        Task AddToCart(string? passId, string? userId,int quantity);
    }
}
