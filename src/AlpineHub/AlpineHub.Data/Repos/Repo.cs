using AlpineHub.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AlpineHub.Data.Repos
{
    public class Repo : IRepo
    {
        private readonly ApplicationDbContext context;
        public Repo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            DbSet<T>().Remove(entity);
        }

        public async Task DeleteByIdAsync<T>(object id) where T : class
        {
            T? entity = await GetByIdAsync<T>(id);
            if (entity is null)
            {
                return;
            }
            Delete<T>(entity);
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> GetAllReadonly<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }

        public async Task<T?> GetByIdAsync<T>(object id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
        private DbSet<T> DbSet<T>() where T : class
        {
            return context.Set<T>();
        }

    }
}
