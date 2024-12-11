namespace AlpineHub.Core.ViewModels.PassPeriod
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstraints;
    using static Common.EntityValidationMessages;
    public class AddPeriodFormModel
    {
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
