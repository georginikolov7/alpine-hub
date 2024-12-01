using AlpineHub.Core.ViewModels.Lift;

namespace AlpineHub.Core.Contracts
{
    public interface ILiftService
    {
        Task<IEnumerable<AllLiftsViewModel>> GetAllLifts();        
        Task<bool> LiftExistsByIdAsync(Guid id);
        Task<LiftDetailsViewModel?> GetLiftByIdAsync(string id);
    }
}
