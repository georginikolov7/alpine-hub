using AlpineHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlpineHub.Data.Configurations
{
    public class LiftConfiguration : IEntityTypeConfiguration<Lift>
    {
        public void Configure(EntityTypeBuilder<Lift> builder)
        {
            var data = new SeedingData();

            builder.HasData([data.GondolaLift, data.ChairLift, data.SecondChairLift]);
        }
    }
}
