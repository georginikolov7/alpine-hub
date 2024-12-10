
namespace AlpineHub.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidationConstraints;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }

        [PersonalData]
        [MaxLength(UserFirstNameMaxLength)]
        [Comment("First name of user")]
        public string? FirstName { get; set; }

        [PersonalData]
        [MaxLength(UserLastNameMaxLength)]
        [Comment("Last name of user")]
        public string? LastName { get; set; }

        [PersonalData]
        [Comment("Birthdate of user")]
        public DateTime? Birthdate { get; set; }

    }
}
