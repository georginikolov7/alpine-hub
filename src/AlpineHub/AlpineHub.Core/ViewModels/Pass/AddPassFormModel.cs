
namespace AlpineHub.Core.ViewModels.Pass
{
    using System.ComponentModel.DataAnnotations;

    using static AlpineHub.Common.EntityValidationConstraints;
    using static AlpineHub.Common.EntityValidationMessages;
    public class AddPassFormModel
    {

        [Required]
        [StringLength(PassNameMaxLength, MinimumLength = PassNameMinLength, ErrorMessage = FieldLengthError)]
        public string Name { get; set; } = null!;

        [StringLength(PassDescriptionMaxLength, MinimumLength = 0, ErrorMessage = FieldLengthError)]
        public string? Description { get; set; }

        [Range(PassMinPrice, PassMaxPrice, ErrorMessage = NumberOutOfRangeGeneral)]
        public decimal Price { get; set; }

        [Required]
        public string AgeGroupId { get; set; } = null!;
        [Required]
        public string PeriodId { get; set; } = null!;
    }
}
