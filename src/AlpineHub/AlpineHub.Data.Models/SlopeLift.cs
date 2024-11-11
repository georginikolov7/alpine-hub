
namespace AlpineHub.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class SlopeLift
    {
        [Required]
        [Comment("Id of slope")]
        public Guid SlopeId { get; set; }
        [ForeignKey(nameof(SlopeId))]
        public virtual Slope Slope { get; set; } = null!;
        [Required]
        [Comment("Id of lift")]
        public Guid LiftId { get; set; }
        [ForeignKey(nameof(LiftId))]
        public virtual Lift Lift { get; set; } = null!;
    }
}
