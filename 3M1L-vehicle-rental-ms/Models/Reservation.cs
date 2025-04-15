using System.ComponentModel.DataAnnotations;
using MathNet.Numerics;
using Microsoft.EntityFrameworkCore;

namespace _3M1L_vehicle_rental_ms.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        [Required]
        public Customer CustomerInfo { get; set; }

        [Required]
        public Vehicle VehicleInfo { get; set; }

        [Required]
        public required DateTime ReservationDate { get; set; }

        [Required]
        [Precision(18, 2)]
        public required double ReservationCost { get; set; }
    }
}
