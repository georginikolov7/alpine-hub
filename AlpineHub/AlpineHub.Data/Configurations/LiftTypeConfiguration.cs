using AlpineHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AlpineHub.Data.Configurations
{
    public class LiftTypeConfiguration : IEntityTypeConfiguration<LiftType>
    {
        public void Configure(EntityTypeBuilder<LiftType> builder)
        {
            var data = new SeedingData();
            builder.HasData([data.GondolaLiftType, data.ChairliftType]);
        }
    }
}
