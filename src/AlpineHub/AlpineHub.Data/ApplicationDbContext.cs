
namespace AlpineHub.Data
{
    using AlpineHub.Data.Configurations;
    using AlpineHub.Data.Models;
    using AlpineHub.Data.Models.Contracts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;
    using System.Reflection.Emit;
    using System.Threading;
    using System.Threading.Tasks;

    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Slope> Slopes { get; set; }
        public DbSet<Lift> Lifts { get; set; }
        public DbSet<LiftType> LiftTypes { get; set; }
        public DbSet<SlopeLift> SlopesLifts { get; set; }
        public DbSet<PassAgeGroup> PassAgeGroups { get; set; }
        public DbSet<PassPeriod> PassPeriods { get; set; }
        public DbSet<PassType> PassTypes { get; set; }
        public DbSet<Passes> Passes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(SlopesLiftsConfiguration).Assembly);


            // Apply global query filter only for Soft deletable entities:
            ApplySoftDeleteFilter(builder);
        }

        public override int SaveChanges()
        {
            OnBeforeSaveChanges();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaveChanges();
            return base.SaveChangesAsync(cancellationToken);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaveChanges();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        /// <summary>
        /// Filter for deleting soft-deletable entities automatically
        /// </summary>
        private void OnBeforeSaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                // Check if the entity implements ISoftDeletable
                if (entry.Entity is ISoftDeletable softDeletableEntity)
                {
                    if (entry.State == EntityState.Deleted)
                    {
                        // Convert to soft delete
                        entry.State = EntityState.Modified;
                        softDeletableEntity.IsDeleted = true;
                    }
                }
            }
        }

        /// <summary>
        /// Method applies query filter to all entities that implement ISoftDeletable
        /// </summary>
        /// <param name="builder"></param>
        private void ApplySoftDeleteFilter(ModelBuilder builder)
        {
            var softDeleteEntities = typeof(ISoftDeletable).Assembly.GetTypes()
            .Where(type => typeof(ISoftDeletable)
                            .IsAssignableFrom(type)
                            && type.IsClass
                            && !type.IsAbstract);

            foreach (var softDeleteEntity in softDeleteEntities)
            {
                builder.Entity(softDeleteEntity).HasQueryFilter(
                      GenerateQueryFilterLambda(softDeleteEntity));
            }
        }

        /// <summary>
        /// Helper method which generates the lambda expression for the soft deletion filter
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private LambdaExpression? GenerateQueryFilterLambda(Type type)
        {
            var parameter = Expression.Parameter(type, "w");
            var falseConstantValue = Expression.Constant(false);
            var propertyAccess = Expression.PropertyOrField(parameter, nameof(ISoftDeletable.IsDeleted));
            var equalExpression = Expression.Equal(propertyAccess, falseConstantValue);
            var lambda = Expression.Lambda(equalExpression, parameter);

            return lambda;
        }
    }
}
