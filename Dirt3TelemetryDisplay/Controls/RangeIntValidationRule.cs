using System.Globalization;
using System.Windows.Controls;

namespace Dirt3TelemetryDisplay.Controls
{
    public class RangeIntValidationRule : ValidationRule
    {
        public RangeIntDependency Range { get; set; }

        public RangeIntValidationRule() {}

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string valueAsString = value as string;

            if (valueAsString == null || valueAsString.Length == 0)
            {
                return new ValidationResult(false, $"Field is empty.");
            }
            bool isValid = int.TryParse(valueAsString, out int validatedValue);

            if (!isValid)
            {
                return new ValidationResult(false, $"Field contains illegal characters.");
            }
            if ((validatedValue < Range.Min) || (validatedValue > Range.Max))
            {
                return new ValidationResult(
                    false, $"Value must be in the range: {Range.Min}-{Range.Max}.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
