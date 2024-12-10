using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlpineHub.Data.Models
{
    public class UserCart
    {
        [Key]
        [Comment("Primary key of table")]
        public Guid Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Comment("Total price of all items in cart")]
        public decimal TotalCartPrice => CartItems.Sum(ci => ci.TotalPrice);
        [Comment("Foreign key for user")]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;
        public virtual ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
    }
}
