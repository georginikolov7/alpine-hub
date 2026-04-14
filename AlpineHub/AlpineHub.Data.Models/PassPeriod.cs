
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static AlpineHub.Common.EntityValidationConstraints;

namespace AlpineHub.Data.Models
{
    public class PassPeriod
    {
        [Key]
        [Comment("Primary key of table PassPeriods")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(PassPeriodNameMaxLength)]
        [Comment("Name of pass period")]
        public string Name { get; set; } = null!;

        [Required]
        [Comment("Starting hour of pass period")]
        public TimeOnly ValidFromHour { get; set; }

        [Required]
        [Comment("Ending hour of pass period")]
        public TimeOnly ValidToHour { get; set; }

        [Comment("Number of days for pass validity")]
        public int DaysCount { get; set; }

        public virtual ICollection<Pass> Passes { get; set; } = new HashSet<Pass>();

    }
}
