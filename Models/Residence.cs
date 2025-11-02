using System.ComponentModel.DataAnnotations;
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
        public int BathroomNumber { get; set; }

        [Required(ErrorMessage = "Enter a PricePerNight.")]
        public string PricePerNight { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter a Location.")]
        public int LocationId { get; set; }
        [ValidateNever]
        public Location Location { get; set; } = null!;
    }
}
