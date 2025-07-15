using System.ComponentModel.DataAnnotations;

namespace taskApi.Validators
{
    public class ValidDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is not DateTime date)
                return false;

            // Reject default date (0001-01-01) or past dates if you want
            return date > DateTime.MinValue;
        }
    }
}
