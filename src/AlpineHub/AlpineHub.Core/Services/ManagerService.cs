using AlpineHub.Core.Contracts;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;
namespace AlpineHub.Core.Services
{
    public class ManagerService(IRepo repo) : BaseService(repo), IManagerService
    {
        public async Task<bool> IsUserManagerAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return false;
            }

            if (!IsGuidValid(userId, out Guid guid))
            {
                return false;
            }

            return await repo.GetByIdAsync<ResortManager>(guid) is not null;
        }
    }
}
