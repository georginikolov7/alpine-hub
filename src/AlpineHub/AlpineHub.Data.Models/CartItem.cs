using AlpineHub.Data.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlpineHub.Data.Models
{
    public class CartItem : ISoftDeletable
    {
        [Key]
        [Comment("Primary key of table")]
        public Guid Id { get; set; }
        [Comment("Number of passes")]
        public int Quantity { get; set; }
        [Comment("Total price of passes")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        [Required]
        [Comment("Foreign key for pass")]
        public Guid PassId { get; set; }
        [ForeignKey(nameof(PassId))]
        public virtual Pass Pass { get; set; } = null!;
        [Required]
        [Comment("Foreign key for cart")]
        public Guid CartId { get; set; }
        [ForeignKey(nameof(CartId))]
        public virtual UserCart Cart { get; set; } = null!;
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
