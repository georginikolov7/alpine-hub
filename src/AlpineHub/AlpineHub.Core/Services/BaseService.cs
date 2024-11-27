using AlpineHub.Data.Contracts;

namespace AlpineHub.Core.Services
{
    public abstract class BaseService
    {
        protected readonly IRepo repo;
        protected BaseService(IRepo repo)
        {
            this.repo = repo;
        }
    }
}
