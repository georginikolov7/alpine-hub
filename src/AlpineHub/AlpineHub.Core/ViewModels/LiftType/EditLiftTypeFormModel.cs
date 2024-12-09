
namespace AlpineHub.Core.ViewModels.LiftType
{

    using System.ComponentModel.DataAnnotations;
    using static AlpineHub.Common.EntityValidationConstraints;
    using static AlpineHub.Common.EntityValidationMessages;
    public class EditLiftTypeFormModel

    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [StringLength(LiftTypeNameMaxLength, MinimumLength = LiftTypeNameMinLength, ErrorMessage = FieldLengthError)]
        public string Name { get; set; } = null!;
    }
}
