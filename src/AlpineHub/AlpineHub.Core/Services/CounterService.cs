using AlpineHub.Core.Contracts;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AlpineHub.Core.Services
{
    public class CounterService(IRepo repo) : BaseService(repo), ICountersService
    {
        public async Task<int> GetNumberOfOpenLiftsAsync()
        {
            return (await repo.GetAllReadonly<Lift>().ToListAsync()).Count(l=>l.IsOpen && IsLiftOpen(l));
        }

        public async Task<int> GetTotalNumberOfLiftsAsync()
        {
            return await repo.GetAllReadonly<Lift>().CountAsync();
        }
        public async Task<int> GetNumberOfOpenSlopesAsync()
        {
            return await repo.GetAllReadonly<Slope>().CountAsync(s => s.IsOpen);
        }

        public async Task<int> GetTotalNumberOfSlopesAsync()
        {
            return await repo.GetAllReadonly<Slope>().CountAsync();
        }
    }
}
