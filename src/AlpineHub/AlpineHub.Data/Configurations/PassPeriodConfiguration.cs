using AlpineHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlpineHub.Data.Configurations
{
    public class PassPeriodConfiguration : IEntityTypeConfiguration<PassPeriod>
    {
        public void Configure(EntityTypeBuilder<PassPeriod> builder)
        {
            var data = new SeedingData();
            builder.HasData(
                data.Morning,
                data.Afternoon,
                data.AllDay
                );
        }
    }
}
