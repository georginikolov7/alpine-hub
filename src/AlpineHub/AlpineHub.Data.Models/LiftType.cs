using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpineHub.Data.Models
{
    using static Common.EntityValidationConstraints;
    public class LiftType
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(LiftTypeNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual IEnumerable<Lift> Lifts { get; set; } = new HashSet<Lift>();
    }
}
