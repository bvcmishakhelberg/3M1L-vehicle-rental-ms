using System.ComponentModel.DataAnnotations;
namespace _3M1L_vehicle_rental_ms.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }


        //// Foreign key for Customer
        //public int CustomerID { get; set; }
        //public Customer Customer { get; set; }


        //// Foreign key for Reservation
        //public int ReservationId { get; set; }
        //public Reservation Reservation { get; set; }


        //// Foreign key for Vehicle
        //public int VehicleID { get; set; }
        //public Vehicle Vehicle { get; set; }
    }
}
