
namespace AlpineHub.Core.ValidationProperties
{
    using System.ComponentModel.DataAnnotations;

    public class ValueHigherThanPropertyAttribute(string propertyToCompare) : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not null)
            {
                //get other value using reflection:
                var valueToCompare = validationContext.ObjectType.GetProperty(propertyToCompare)?.GetValue(validationContext.ObjectInstance, null);

                if (valueToCompare is not null)
                {
                    try
                    {
                        if ((int)value <= (int)valueToCompare)
                        {
                            return new ValidationResult(ErrorMessage = "Top value must be higher than bottom value");
                        }
                    }
                    catch (Exception ex)
                    {
                        return new ValidationResult("Invalid property type.");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
