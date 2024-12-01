using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlpineHub.Data.Models
{
    public class ResortManager
    {
        [Key]
        [Comment("Primary key for ResortManager")]
        public Guid Id { get; set; }
        [Required]
        [Comment("Foreign key for user relation(1-1)")]
        public Guid ApplicationUserId { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUserId))]
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
