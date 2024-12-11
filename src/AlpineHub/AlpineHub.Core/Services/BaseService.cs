using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;

namespace AlpineHub.Core.Services
{
    public abstract class BaseService
    {
        protected readonly IRepo repo;
        protected BaseService(IRepo repo)
        {
            this.repo = repo;
        }
        protected bool IsGuidValid(string? id, out Guid guid)
        {
            // Non-existing parameter in the URL
            if (String.IsNullOrWhiteSpace(id))
            {
                guid = Guid.Empty;
                return false;
            }

            var isValid = Guid.TryParse(id, out guid);
            if (isValid)
            {
                return true;
            }
            return false;
        }


        
    }
}
