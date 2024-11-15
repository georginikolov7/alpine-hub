
namespace AlpineHub.Data.Models
{
    using static Common.EntityValidationConstraints;

    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using AlpineHub.Data.Models.Contracts;

    public class Passes : ISoftDeletable
    {
        [Key]
        [Comment("Primary key of table")]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("Pass price. Pass type discount is automatically deduced")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Start of validity period")]
        public DateTime ValidFromDate { get; set; }

        [Required]
        [Comment("End of validity period")]
        public DateTime ValidToDate { get; set; }

        [Required]
        [Comment("Flag for soft deletion")]
        public bool IsDeleted { get; set; }


        [Required]
        [Comment("Foreign key for pass type")]
        public Guid PassTypeId { get; set; }

        [Required]
        [ForeignKey(nameof(PassTypeId))]
        public virtual PassType PassType { get; set; } = null!;

        [Required]
        [Comment("Foreign key for pass age group")]

        public Guid PassAgeGroupId { get; set; }
        [Required]
        [ForeignKey(nameof(PassAgeGroupId))]
        public virtual PassAgeGroup PassAgeGroup { get; set; } = null!;

        [Required]
        [Comment("Foreign key for pass period")]
        public Guid PassPeriodId { get; set; }

        [Required]
        [ForeignKey(nameof(PassPeriodId))]
        public virtual PassPeriod PassPeriod { get; set; } = null!;



    }
}
