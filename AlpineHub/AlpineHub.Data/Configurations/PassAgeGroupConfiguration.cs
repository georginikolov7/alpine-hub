using AlpineHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlpineHub.Data.Configurations
{
    public class PassAgeGroupConfiguration : IEntityTypeConfiguration<PassAgeGroup>
    {
        public void Configure(EntityTypeBuilder<PassAgeGroup> builder)
        {
            var data = new SeedingData();
            builder.HasData(
                [data.AdultGroup, data.StudentGroup, data.ChildGroup]
                );
        }
    }
}
