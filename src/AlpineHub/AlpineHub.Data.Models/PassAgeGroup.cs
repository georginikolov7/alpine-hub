
namespace AlpineHub.Data.Models
{
    using static Common.EntityValidationConstraints;

    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    public class PassAgeGroup
    {
        [Key]
        [Comment("Primary key of table")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(PassAgeGroupMaxLength)]
        [Comment("Name of age group")]
        public string Name { get; set; } = null!;

        [Comment("Min age of client")]
        public int MinAge { get; set; }

        [Comment("Max age of client")]
        public int MaxAge { get; set; }
    }
}
