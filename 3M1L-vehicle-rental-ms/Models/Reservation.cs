using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MathNet.Numerics;
using Microsoft.EntityFrameworkCore;

namespace _3M1L_vehicle_rental_ms.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        // Foreign key for Customer
        [Required]
        public int CustomerInfoId { get; set; }

        //[ForeignKey("CustomerInfoId")]
        public Customer CustomerInfo { get; set; }

        // Foreign key for Vehicle
        [Required]
        public int VehicleInfoId { get; set; }

        //[ForeignKey("VehicleInfoId")]
        public Vehicle VehicleInfo { get; set; }

        [Required]
        public required DateTime ReservationDate { get; set; }

        [Required]
        [Precision(18, 2)]
        public required double ReservationCost { get; set; }
    }
}
