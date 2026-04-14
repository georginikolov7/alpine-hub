using AlpineHub.Core.DTOs;
using AlpineHub.Core.ViewModels.Slope;

namespace AlpineHub.Core.Contracts.Slope
{
    public interface ISlopeService
    {
        Task<IEnumerable<AllSlopesViewModel>> GetAllSlopesAsync();
        Task<IEnumerable<AllSlopesDto>?> GetAllSlopesForMapAsync();
        Task<SlopeDetailsViewModel?> GetSlopeByIdAsync(string? id);
        Task<bool> SlopeExistsByIdAsync(Guid id);
        Task<int> GetNumberOfOpenSlopesAsync();
        Task<int> GetTotalNumberOfSlopesAsync();

        Task<SlopeDetailsDto> GetSlopeDetailsForMapAsync(string? id);
    }
}
