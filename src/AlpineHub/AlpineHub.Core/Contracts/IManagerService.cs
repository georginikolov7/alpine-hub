namespace AlpineHub.Core.Contracts
{
    public interface IManagerService
    {
        Task<bool> IsManagerIdValid(string? managerId, string? userId);
        Task<bool> IsUserManager(string? userId);
    }
}
