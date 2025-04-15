namespace _3M1LVehicleRentalsMs.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}