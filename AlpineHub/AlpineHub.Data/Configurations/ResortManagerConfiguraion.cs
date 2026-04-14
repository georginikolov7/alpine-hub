using AlpineHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlpineHub.Data.Configurations
{
    public class ResortManagerConfiguraion : IEntityTypeConfiguration<ResortManager>
    {
        public void Configure(EntityTypeBuilder<ResortManager> builder)
        {
            var data = new SeedingData();
            builder.HasData(data.ResortManager);
        }
    }
}
