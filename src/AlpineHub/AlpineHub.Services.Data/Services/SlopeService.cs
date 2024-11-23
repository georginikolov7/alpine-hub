using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;
using AlpineHub.Services.Data.Contracts;
using AlpineHub.Services.Data.ViewModels.Slope;
using Microsoft.EntityFrameworkCore;

namespace AlpineHub.Services.Data.Services
{
    public class SlopeService : ISlopeService
    {
        private readonly IRepo repo;

        public SlopeService(IRepo repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<AllSlopesViewModel>> GetAllSlopes()
        {
            IEnumerable<AllSlopesViewModel> slopes = await repo.GetAllReadonly<Slope>()
                .Select(s => new AllSlopesViewModel()
                {
                    Id = s.Id.ToString(),
                    Name = s.Name,
                    Difficulty = s.Difficulty.ToString(),
                    IsOpen = s.IsOpen,
                }).ToListAsync();

            return slopes;
        }
    }
}
