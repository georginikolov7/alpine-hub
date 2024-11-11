using AlpineHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlpineHub.Data.Configurations
{
    public class SlopesLiftsConfiguration : IEntityTypeConfiguration<SlopeLift>
    {
        public void Configure(EntityTypeBuilder<SlopeLift> builder)
        {
            builder.HasKey(pk => new { pk.SlopeId, pk.LiftId });
        }
    }
}
