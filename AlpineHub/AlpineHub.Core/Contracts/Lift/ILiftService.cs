using AlpineHub.Core.DTOs;
using AlpineHub.Core.ViewModels.Lift;

namespace AlpineHub.Core.Contracts.Lift
{
    public interface ILiftService
    {
        Task<IEnumerable<AllLiftsViewModel>> GetAllLiftsDetailsAsync();
        Task<bool> LiftExistsByIdAsync(Guid id);
        Task<LiftDetailsViewModel?> GetLiftByIdAsync(string id);
        Task<int> GetNumberOfOpenLiftsAsync();
        Task<int> GetTotalNumberOfLiftsAsync();
        Task<IEnumerable<AllLiftsDto>?> GetAllLiftsForMapAsync();
        Task<LiftDetailsDto> GetLiftDetailsForMapByIdAsync(string? id);
    }
}
