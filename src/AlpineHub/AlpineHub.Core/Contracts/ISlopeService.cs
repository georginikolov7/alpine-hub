using AlpineHub.Core.ViewModels.Slope;

namespace AlpineHub.Core.Contracts
{
    public interface ISlopeService
    {
        Task<IEnumerable<AllSlopesViewModel>> GetAllSlopesAsync();
        Task<int> GetNumberOfOpenSlopesAsync();
        Task<int> GetTotalNumberOfSlopesAsync();
        Task<SlopeDetailsViewModel?> GetSlopeByIdAsync(string id);
        Task<bool> SlopeExistsByIdAsync(Guid id);
    }
}
