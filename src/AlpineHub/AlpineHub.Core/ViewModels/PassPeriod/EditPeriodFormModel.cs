using System.ComponentModel.DataAnnotations;
using static AlpineHub.Common.EntityValidationConstraints;
using static AlpineHub.Common.EntityValidationMessages;

namespace AlpineHub.Core.ViewModels.PassPeriod
{
    public class EditPeriodFormModel
    {
        [Required]
        public string Id { get; set; } = null!;
        [Required]
        [StringLength(PassPeriodNameMaxLength, MinimumLength = PassPeriodNameMinLength, ErrorMessage = FieldLengthError)]
        public string Name { get; set; } = null!;
        [Required]
        public TimeOnly ValidFromHour { get; set; }
        [Required]
        public TimeOnly ValidToHour { get; set; }
        [Range(PassPeriodDaysCountMin, PassPeriodDaysCountMax, ErrorMessage = NumberOutOfRangeGeneral)]
        public int DaysCount { get; set; }
    }
}

