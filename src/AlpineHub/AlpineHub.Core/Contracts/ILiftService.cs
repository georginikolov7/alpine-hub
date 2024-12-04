using AlpineHub.Core.ViewModels.Lift;
using AlpineHub.Core.ViewModels.LiftType;

namespace AlpineHub.Core.Contracts
{
    public interface ILiftService
    {
        Task<IEnumerable<AllLiftsViewModel>> GetAllLifts();
        Task<bool> LiftExistsByIdAsync(Guid id);
        Task<LiftDetailsViewModel?> GetLiftByIdAsync(string id);
        Task<int> GetNumberOfOpenLiftsAsync();
        Task<int> GetTotalNumberOfLiftsAsync();
        Task<IEnumerable<LiftTypeViewModel>>? GetAllLiftTypesAsync();
    }
}
