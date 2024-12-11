using System.ComponentModel.DataAnnotations;

using AlpineHub.Core.ValidationProperties;

using static AlpineHub.Common.EntityValidationConstraints;
using static AlpineHub.Common.EntityValidationMessages;

namespace AlpineHub.Core.ViewModels.PassAgeGroup
{
    public class EditAgeGroupFormModel
    {
        [Required]
        public string Id { get; set; } = null!;
        [Required]
        [StringLength(PassAgeGroupMaxLength, MinimumLength = PassAgeGroupMinLength, ErrorMessage = FieldLengthError)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(PassAgeGroupMinAge, PassAgeGroupMaxAge, ErrorMessage = NumberOutOfRangeGeneral)]
        public int MinAge { get; set; }

        [Required]
        [ValueHigherThanProperty(nameof(MinAge))]
        [Range(PassAgeGroupMinAge, PassAgeGroupMaxAge, ErrorMessage = NumberOutOfRangeGeneral)]
        public int MaxAge { get; set; }
    }
}
