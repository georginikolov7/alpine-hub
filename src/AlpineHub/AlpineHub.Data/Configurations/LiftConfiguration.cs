using AlpineHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
