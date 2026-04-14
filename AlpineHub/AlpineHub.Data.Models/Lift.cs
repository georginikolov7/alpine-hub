
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using AlpineHub.Data.Models.Contracts;

using static AlpineHub.Common.EntityValidationConstraints;

namespace AlpineHub.Data.Models
{
    public class Lift : ISoftDeletable
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

        [Comment("Max number of people per hour")]
        public int CapacityPerHour { get; set; }

        [Comment("Average ascend time in minutes")]
        public int AverageAscendTime { get; set; }

        [Comment("Number of seats of lift")]
        public int NumberOfSeats { get; set; }

        [Required]
        [Comment("Openning hour of lift")]
        public TimeOnly OpenningTime { get; set; }

        [Required]
        [Comment("Closing hour of lift")]
        public TimeOnly ClosingTime { get; set; }

        [Required]
        [Comment("Lift status flag")]
        public bool IsOpen { get; set; }

        [Required]
        [Comment("Foreign key for lift type relation")]
        public Guid LiftTypeId { get; set; }

        [ForeignKey(nameof(LiftTypeId))]
        public virtual LiftType LiftType { get; set; } = null!;
        [Comment("Soft delete flag")]
        public bool IsDeleted { get; set; }
    }
}
