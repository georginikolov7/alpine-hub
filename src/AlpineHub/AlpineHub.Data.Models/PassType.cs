
namespace AlpineHub.Data.Models
{
    using static Common.EntityValidationConstraints;

    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PassType
    {
        [Key]
        [Comment("Primary key of table")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(PassTypeNameMaxLength)]
        [Comment("Name of pass type")]
        public string Name { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("Discount of current pass type")]
        public decimal DiscountPercentage { get; set; }

        [Required]
        [Comment("Start of validity period")]
        public DateTime ValidFromDate { get; set; }

        [Required]
        [Comment("End of validity period")]
        public DateTime ValidToDate { get; set; }
    }
}
