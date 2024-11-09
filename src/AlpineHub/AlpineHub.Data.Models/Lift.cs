using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlpineHub.Data.Models
{
    using static Common.EntityValidationConstraints;
    public class Lift
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(LiftNameMaxLength)]
        [Comment("Name of ski lift")]
        public string Name { get; set; } = null!;

        [Comment("Length of ski lift in meters")]
        public int Length { get; set; }

        [Comment("Vertical ascend of lift in meters")]
        public int VerticalAscend { get; set; }

        [Comment("Average ascend time in minutes")]
        public int AverageAscendTime { get; set; }

        [Required]
        [Comment("Openning hour of lift")]
        public TimeOnly OpenningHour { get; set; }

        [Required]
        [Comment("Closing hour of lift")]
        public TimeOnly ClosedHour { get; set; }

        [Required]
        [Comment("Last time to ride lift from bottom station")]
        public TimeOnly LastRideFromBottomStationTime { get; set; }

        [Required]
        [Comment("Last time to ride lift from top station")]
        public TimeOnly LastRideFromTopStationTime { get; set; }

        [Required]
        [Comment("Foreign key for lift type relation")]
        public Guid LiftTypeId { get; set; }

        [ForeignKey(nameof(LiftTypeId))]
        public virtual LiftType LiftType { get; set; } = null!;
    }
}
