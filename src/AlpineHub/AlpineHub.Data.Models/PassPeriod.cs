
namespace AlpineHub.Data.Models
{
    using static Common.EntityValidationConstraints;

    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    public class PassPeriod
    {
        [Key]
        [Comment("Primary key of table PassPeriods")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(PassPeriodNameMaxLength)]
        [Comment("Name of pass period")]
        public string Name { get; set; } = null!;

        [Comment("Starting hour of pass period")]
        public int ValidFromHour { get; set; }

        [Comment("Ending hour of pass period")]
        public int ValidToHour { get; set; }
        [Comment("Number of days for pass validity")]
        public int DaysCount { get; set; }
    }
}
