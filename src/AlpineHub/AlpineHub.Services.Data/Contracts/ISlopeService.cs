using AlpineHub.Services.Data.ViewModels.Slope;

namespace AlpineHub.Services.Data.Contracts
{
    public interface ISlopeService
    {
        Task<IEnumerable<AllSlopesViewModel>> GetAllSlopes();
    }
}
