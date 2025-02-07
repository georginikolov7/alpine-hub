using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using AlpineHub.Core.Contracts;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;

using static AlpineHub.Data.Constants.CustomClaims;

namespace AlpineHub.Core.Services
{
    public class ManagerService(IRepo repo, UserManager<ApplicationUser> userManager) : BaseService(repo), IManagerService
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

        public async Task MakeUserManager(ApplicationUser user)
        {
            ResortManager manager = new()
            {
                ApplicationUserId = user.Id,
            };
            await repo.AddAsync<ResortManager>(manager);
            await repo.SaveChangesAsync();

            //Add cookie to user:
            await userManager.AddClaimAsync(user, new Claim(ManagerIdClaim, manager.Id.ToString()));
        }

        public async Task RemoveManager(ApplicationUser user)
        {
            ResortManager? manager = await repo.GetAll<ResortManager>().FirstOrDefaultAsync(m => m.ApplicationUserId == user.Id);
            if (manager is not null)
            {
                repo.Delete(manager);
                await repo.SaveChangesAsync();

                await userManager.RemoveClaimAsync(user, new Claim(ManagerIdClaim, manager.Id.ToString()));
            }
        }
    }
}
