using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Airbnb.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        [Required(ErrorMessage = "Enter a ReservationStartDate.")]
        public DateTime ReservationStartDate { get; set; }

        [Required(ErrorMessage = "Enter a ReservationEndDate.")]
        public DateTime ReservationEndDate { get; set; }

        [Required(ErrorMessage = "Enter a Residence.")]
        public int ResidenceId { get; set; }
        [ValidateNever]
        public Residence Residence { get; set; } = null!;
    }
}
