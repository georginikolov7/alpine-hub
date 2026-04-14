using System.ComponentModel.DataAnnotations;
using static AlpineHub.Common.EntityValidationConstraints;
using static AlpineHub.Common.EntityValidationMessages;
namespace AlpineHub.Core.ViewModels.LiftType
{
    public class AddLiftTypeFormModel
    {
        [Required]
        [StringLength(LiftTypeNameMaxLength, MinimumLength = LiftTypeNameMinLength, ErrorMessage = FieldLengthError)]
        public string Name { get; set; } = null!;
    }
}
