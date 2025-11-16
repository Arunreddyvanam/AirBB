using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Airbnb.Models
{
    public class BuiltYearRangeAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly int maxYears;

        public BuiltYearRangeAttribute(int years)
        {
            maxYears = years;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext ctx)
        {
            if (value is DateTime date)
            {
                DateTime today = DateTime.Today;
                DateTime earliestAllowed = today.AddYears(-maxYears);

                if (date <= today && date >= earliestAllowed)
                {
                    return ValidationResult.Success!;
                }
            }

            return new ValidationResult(GetMsg(ctx.DisplayName ?? "Built year"));
        }

        public void AddValidation(ClientModelValidationContext ctx)
        {
            if (!ctx.Attributes.ContainsKey("data-val"))
                ctx.Attributes.Add("data-val", "true");

            ctx.Attributes.Add("data-val-builtyearrange-years", maxYears.ToString());
            ctx.Attributes.Add("data-val-builtyearrange",
                GetMsg(ctx.ModelMetadata.DisplayName ?? ctx.ModelMetadata.Name ?? "Built year"));
        }

        private string GetMsg(string name)
        {
            return base.ErrorMessage ??
                $"{name} must be a past year and no more than {maxYears} years old.";
        }
    }
}
