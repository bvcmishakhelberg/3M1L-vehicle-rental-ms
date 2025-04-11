using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace _3M1L_vehicle_rental_ms.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        [Required]
        public Customer CustomerInfo { get; set; }

        [Required]
        public Admin AdminInfo { get; set; }

        [Required]
        public Vehicle VehicleInfo { get; set; }

        [Required]
        public required DateTime ReservationDate { get; set; }
        
        [Required]
        [Precision(18, 2)]
        public required Double ReservationCost { get; set; }
    }
}
