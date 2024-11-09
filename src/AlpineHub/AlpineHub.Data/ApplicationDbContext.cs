using AlpineHub.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlpineHub.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Slope> Slopes { get; set; }
        public DbSet<Lift> Lifts { get; set; }
        public DbSet<SlopeLift> SlopesLifts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //TODO COMPOSITE PRIMARY KEY
            base.OnModelCreating(builder);
        }
    }
}
