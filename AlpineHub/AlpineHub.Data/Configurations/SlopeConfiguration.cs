using AlpineHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlpineHub.Data.Configurations
{
    internal class SlopeConfiguration : IEntityTypeConfiguration<Slope>
    {
        public void Configure(EntityTypeBuilder<Slope> builder)
        {
            var data = new SeedingData();

            builder.HasData([data.FirstSlope, data.SecondSlope, data.ThirdSlope]);
        }
    }
}
