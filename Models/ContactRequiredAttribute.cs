using System.ComponentModel.DataAnnotations;

namespace Airbnb.Models
{
    public class ContactRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var user = (User)validationContext.ObjectInstance;

            if (string.IsNullOrWhiteSpace(user.Email) && string.IsNullOrWhiteSpace(user.PhoneNumber))
            {
                return new ValidationResult("Either Email or PhoneNumber must be provided.");
            }

            return ValidationResult.Success;
        }
    }
}
