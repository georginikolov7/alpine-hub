using AlpineHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlpineHub.Data.Configurations
{
    public class PassConfiguration : IEntityTypeConfiguration<Pass>
    {
        public void Configure(EntityTypeBuilder<Pass> builder)
        {
            var data = new SeedingData();
            builder.HasData(
                data.AllDayAdultPass,
                data.AllDayStudentPass,
                data.AllDayChildPass
                );
        }
    }
}
