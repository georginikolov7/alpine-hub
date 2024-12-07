using System.ComponentModel.DataAnnotations;

namespace AlpineHub.Core.ViewModels.User
{
    public class RoleFormModel
    {
        [Required]
        public string UserId { get; set; } = null!;
        [Required]
        public string RoleName { get; set; } = null!;
    }
}
