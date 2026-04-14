namespace AlpineHub.Data.Contracts
{
    public interface IRepo
    {
        IQueryable<T> GetAll<T>() where T : class;
        IQueryable<T> GetAllReadonly<T>() where T : class;
        Task AddAsync<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task DeleteByIdAsync<T>(object id) where T : class;
        Task<T?> GetByIdAsync<T>(object id) where T : class;
        Task<int> SaveChangesAsync();
    }
}
