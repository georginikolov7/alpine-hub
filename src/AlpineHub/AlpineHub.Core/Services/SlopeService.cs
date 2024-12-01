using AlpineHub.Core.Contracts;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;
using AlpineHub.Core.ViewModels.Slope;
using Microsoft.EntityFrameworkCore;

namespace AlpineHub.Core.Services
{
    public class SlopeService(IRepo repo) : BaseService(repo), ISlopeService
    {
        public async Task<IEnumerable<AllSlopesViewModel>> GetAllSlopesAsync()
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
        public async Task<int> GetNumberOfOpenSlopesAsync()
        {
            return await repo.GetAllReadonly<Slope>().CountAsync(s => s.IsOpen);
        }

        public async Task<int> GetTotalNumberOfSlopesAsync()
        {
            return await repo.GetAllReadonly<Slope>().CountAsync();
        }
        public async Task<bool> SlopeExistsByIdAsync(Guid slopeId)
        {
            return await repo.GetAllReadonly<Slope>().AnyAsync(s => s.Id == slopeId);
        }
        public async Task<SlopeDetailsViewModel?> GetSlopeByIdAsync(string slopeId)
        {
            if (!IsGuidValid(slopeId, out Guid guid))
            {
                return null;
            }

            var slope = await repo.GetByIdAsync<Slope>(guid);
            if (slope == null)
            {
                return null;
            }

            SlopeDetailsViewModel model = new SlopeDetailsViewModel()
            {
                Id = slope.Id.ToString(),
                Name = slope.Name,
                Difficulty = slope.Difficulty.ToString(),
                SlopeCondition = slope.SlopeCondition.ToString(),
                IsOpen = slope.IsOpen,
                Length = slope.Length,
                UpperPointElevation = slope.UpperPointAltitude,
                LowerPointElevation = slope.LowerPointAltitude,
            };

            return model; //evala goshe
        }
    }
}
