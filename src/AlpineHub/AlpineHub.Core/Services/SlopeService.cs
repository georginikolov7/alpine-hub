using AlpineHub.Core.Contracts;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;
using AlpineHub.Core.ViewModels.Slope;
using Microsoft.EntityFrameworkCore;

namespace AlpineHub.Core.Services
{
    public class SlopeService(IRepo repo) : BaseService(repo), ISlopeService
    {
        public async Task<IEnumerable<AllSlopesViewModel>> GetAllSlopes()
        {
            IEnumerable<AllSlopesViewModel> slopes = await repo.GetAllReadonly<Slope>()
                .Select(s => new AllSlopesViewModel()
                {
                    Id = s.Id.ToString(),
                    Name = s.Name,
                    Difficulty = s.Difficulty.ToString(),
                    SlopeCondition = s.SlopeCondition.ToString(),
                    IsOpen = s.IsOpen,
                }).ToListAsync();

            return slopes;
        }

        public async Task<int> GetNumberOfOpenSlopes()
        {
            return await repo.GetAllReadonly<Slope>().CountAsync(s => s.IsOpen);
        }

        public async Task<int> GetTotalNumberOfSlopes()
        {
            return await repo.GetAllReadonly<Slope>().CountAsync();s
        }
    }
}
