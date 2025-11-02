using System.ComponentModel.DataAnnotations;

namespace Airbnb.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Enter a Name.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter a PhoneNumber.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter a Email.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter a DOB.")]
        public string DOB { get; set; } = string.Empty;
    }
}
