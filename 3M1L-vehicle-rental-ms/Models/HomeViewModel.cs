namespace _3M1L_vehicle_rental_ms.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}