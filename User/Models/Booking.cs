using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using User.Models;

namespace CabInventoryManagement.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public string Onboarding { get; set; }
        [Required]
        public string Destination { get; set; }

        [Required]
        public DateTime PickupTime { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
