using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DAL.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class LessThanAttribute : ValidationAttribute
    {
        /*------------------------------------------------------------------------*/
        private readonly string _comparisonProperty;
        /*------------------------------------------------------------------------*/
        public LessThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }
        /*------------------------------------------------------------------------*/
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (property == null)
            {
                return new ValidationResult($"Unknown property: {_comparisonProperty}");
            }

            var comparisonValue = property.GetValue(validationContext.ObjectInstance);

            if (value == null || comparisonValue == null)
            {
                return ValidationResult.Success;
            }

            if (decimal.TryParse(value.ToString(), out decimal currentValue) && decimal.TryParse(comparisonValue.ToString(), out decimal comparisonValueDecimal))
            {
                if (currentValue >= comparisonValueDecimal)
                {
                    return new ValidationResult(ErrorMessage ?? $"The field {validationContext.MemberName} must be less than {_comparisonProperty}.");
                }
            }

            // If none of the conditions above are met, return ValidationResult.Success
            return ValidationResult.Success;
        }
        /*------------------------------------------------------------------------*/
    }
}
