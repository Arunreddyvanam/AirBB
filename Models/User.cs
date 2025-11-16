using System.ComponentModel.DataAnnotations;

namespace Airbnb.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Enter a Name.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter a SSN.")]
        public string SSN { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        [Required(ErrorMessage = "Enter a DOB.")]
        public DateTime? DOB { get; set; }
        
        [Required(ErrorMessage = "Enter a UserType.")]
        public string UserType { get; set; } = string.Empty;

        [ContactRequired] // Apply the custom validation
        public string ContactCheck => $"{PhoneNumber}-{Email}";
    }
}
