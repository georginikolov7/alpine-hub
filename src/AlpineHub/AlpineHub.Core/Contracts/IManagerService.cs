namespace AlpineHub.Core.Contracts
{
    public interface IManagerService
    {
        Task<bool> IsUserManagerAsync(string userId);
    }
}
