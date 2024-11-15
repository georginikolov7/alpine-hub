
namespace AlpineHub.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstraints;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
           this.Id = Guid.NewGuid();
        }


        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        [Comment("First name of user")]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(UserLastNameMaxLength)]
        [Comment("Last name of user")]
        public string LastName { get; set; } = null!;
    }
}
