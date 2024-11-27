using AlpineHub.Core.ViewModels.Slope;

namespace AlpineHub.Core.Contracts
{
    public interface ISlopeService
    {
        Task<IEnumerable<AllSlopesViewModel>> GetAllSlopes();
        Task<int> GetNumberOfOpenSlopes();
        Task<int> GetTotalNumberOfSlopes();
    }
}
