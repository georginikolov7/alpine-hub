
namespace AlpineHub.Data.Models
{
    using static Common.EntityValidationConstraints;

    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    public class PassPrices
    {
        [Key]
        [Comment("Primary key of table")]
        public Guid Id { get; set; }


    }
}
