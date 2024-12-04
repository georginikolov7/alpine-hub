using AlpineHub.Core.Contracts;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace AlpineHub.Core.Services
{
    public class ManagerService(IRepo repo) : BaseService(repo), IManagerService
    {
        public async Task<bool> IsManagerIdValid(string? managerId, string? userId)
        {
            if (string.IsNullOrWhiteSpace(managerId) || string.IsNullOrEmpty(userId))
            {
                return false;
            }

            if (!IsGuidValid(managerId, out Guid managerGuid) || !IsGuidValid(userId, out Guid userGuid))
            {
                return false;
            }

            ResortManager? manager = await repo.GetByIdAsync<ResortManager>(managerGuid);
            if (manager is null)
            {
                return false;
            }
            return manager.ApplicationUserId == userGuid;
        }

        public async Task<bool> IsUserManager(string? userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return false;
            }
            if (!IsGuidValid(userId, out Guid guid))
            {
                return false;
            }

            return await repo.GetAllReadonly<ResortManager>().AnyAsync(m => m.ApplicationUserId == guid);
        }
    }
}
