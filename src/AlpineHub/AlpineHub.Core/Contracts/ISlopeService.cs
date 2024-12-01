using AlpineHub.Core.ViewModels.Slope;

namespace AlpineHub.Core.Contracts
{
    public interface ISlopeService
    {
        Task<IEnumerable<AllSlopesViewModel>> GetAllSlopesAsync();

        Task<SlopeDetailsViewModel?> GetSlopeByIdAsync(string id);
        Task<bool> SlopeExistsByIdAsync(Guid id);
    }
}
