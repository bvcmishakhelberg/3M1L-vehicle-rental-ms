using System.ComponentModel.DataAnnotations;
using _3M1LVehicleRentalsMs.Models;

namespace _3M1LVehicleRentalsMs.Models
{
    public class Reports
    {
        [Key]
        public int ReportId { get; set; }

        // Foreign key for Admin
        public int AdminID { get; set; }
        public Admin Admin { get; set; }


        // Foreign key for Customer
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }


        // Foreign key for Reservation
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }


        // Foreign key for Vehicle
        public int VehicleID { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
