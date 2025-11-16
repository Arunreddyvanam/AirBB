using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Airbnb.Models
{
    public class Residence
    {
        public int ResidenceId { get; set; }

        [Required(ErrorMessage = "Enter a Name.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter a ResidencePicture.")]
        public string ResidencePicture { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter a GuestNumber.")]
        public int GuestNumber { get; set; }

        [Required(ErrorMessage = "Enter a BedroomNumber.")]
        public int BedroomNumber { get; set; }

        [Required(ErrorMessage = "Enter a BathroomNumber.")]
        [RegularExpression(@"^\d+(\.5)?$", ErrorMessage = "Bathroom Number must end with .5 when fractional")]
        public decimal BathroomNumber { get; set; }

        [Required(ErrorMessage = "Enter a PricePerNight.")]
        public string PricePerNight { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Built Year.")]
        [BuiltYearRange(150, ErrorMessage = "Built year must be a past year and no more than 150 years ago.")]
        [DataType(DataType.Date)]
        public DateTime? BuildYear { get; set; }

        [Required(ErrorMessage = "Enter a Location.")]
        public int LocationId { get; set; }
        [ValidateNever]
        public Location Location { get; set; } = null!;

        [Required(ErrorMessage = "Please enter an UserId.")]
        [Remote("CheckOwner", "Validation", areaName: "")]
        [Display(Name = "UserId")]
        public int UserId { get; set; }
        [ValidateNever]
        public User User { get; set; } = null!;
    }
}
