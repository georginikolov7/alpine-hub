namespace AlpineHub.Data.Models
{
    using static Common.EntityValidationConstraints;

    using AlpineHub.Common.Enums;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    public class Slope
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(SlopeNameMaxLength)]
        [Comment("Name of the slope")]
        public string Name { get; set; } = null!;

        [Comment("Length of the slope in meters")]
        public int Length { get; set; }

        [Comment("Elevation at upmost point of the slope")]
        public int UpperPointAltitude { get; set; }

        [Comment("Elevation at lowest point of the slope")]
        public int LowerPointAltitude { get; set; }

        [Required]
        [Comment("Slope difficulty enum")]
        public SlopeDifficulty Difficulty { get; set; }

        [Comment("Flag indicating if slope is open")]
        public bool IsOpen { get; set; }

        [Comment("Slope condition enum")]
        [Required]
        public SlopeCondition SlopeCondition { get; set; }
    }
}
