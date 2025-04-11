using System.ComponentModel.DataAnnotations;

namespace _3M1L_vehicle_rental_ms.Models
{
    public class Reports
    {
        [Key]
        public int ReportId { get; set; }
        public Admin Admin { get; set; }
        public Customer Customer { get; set; }
        public Reservation Reservation { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
