using AlpineHub.Common.Enums;
using AlpineHub.Core.ValidationProperties;
using System.ComponentModel.DataAnnotations;
using static AlpineHub.Common.EntityValidationConstraints;
using static AlpineHub.Common.EntityValidationMessages;

namespace AlpineHub.Core.ViewModels.Slope
{
    public class EditSlopeFormModel
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(SlopeNameMaxLength, MinimumLength = SlopeNameMinLength, ErrorMessage = FieldLengthError)]
        public string Name { get; set; } = null!;

        [Required]
        public SlopeDifficulty Difficulty { get; set; }
        [Required]
        public SlopeCondition SlopeCondition { get; set; }
        public bool IsOpen { get; set; }

        [Range(SlopeMinLength, SlopeMaxLength, ErrorMessage = LengthOutOfRange)]
        public int Length { get; set; }

        [ValueHigherThanProperty(nameof(LowerPointAltitude))]
        [Range(ResortMinAltitude, ResortMaxAltitude, ErrorMessage = LengthOutOfRange)]
        public int UpperPointAltitude { get; set; }

        [Range(ResortMinAltitude, ResortMaxAltitude, ErrorMessage = LengthOutOfRange)]
        public int LowerPointAltitude { get; set; }
    }
}
