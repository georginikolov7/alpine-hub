
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static AlpineHub.Common.EntityValidationConstraints;

namespace AlpineHub.Data.Models
{
    public class LiftType
    {
        [Key]
        [Comment("Primary key of table")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(LiftTypeNameMaxLength)]
        [Comment("Name of lift type")]
        public string Name { get; set; } = null!;

        //Mapping property:
        public virtual ICollection<Lift> Lifts { get; set; } = new HashSet<Lift>();
    }
}
