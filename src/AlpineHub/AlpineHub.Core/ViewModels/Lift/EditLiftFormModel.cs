
namespace AlpineHub.Core.ViewModels.Lift
{
    using System.ComponentModel.DataAnnotations;
    using static AlpineHub.Common.EntityValidationConstraints;
    using static AlpineHub.Common.EntityValidationMessages;
    public class EditLiftFormModel
    {
        [Required]
        public string Id { get; set; } = null!;
        [Required]
        [StringLength(LiftNameMaxLength, MinimumLength = LiftNameMinLength, ErrorMessage = FieldLengthError)]
        public string Name { get; set; } = null!;
        [Range(LiftMinLength, LiftMaxLength, ErrorMessage = LengthOutOfRange)]
        public int Length { get; set; }
        [Required]
        public string LiftTypeId { get; set; } = null!;

        [Range(MinVerticalAscend, MaxVerticalAscend, ErrorMessage = LengthOutOfRange)]
        public int VerticalAscend { get; set; }

        [Range(LiftMinCapacity, LiftMaxCapacity, ErrorMessage = NumberOutOfRangeGeneral)]
        public int Capacity { get; set; }

        [Range(LiftMinAscendTime, LiftMaxAscendTime, ErrorMessage = TimeOutOfRange)]
        public int AverageAscendTime { get; set; }

        [Range(LiftMinNumberOfSeats, LiftMaxNumberOfSeats, ErrorMessage = NumberOutOfRangeGeneral)]
        public int SeatsCount { get; set; }

        [Required]
        public TimeOnly OpenningTime { get; set; }
        [Required]
        public TimeOnly ClosingTime { get; set; }

        public bool IsOpen { get; set; }


    }
}
