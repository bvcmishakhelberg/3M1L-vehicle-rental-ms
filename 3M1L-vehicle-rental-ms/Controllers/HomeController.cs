using _3M1LVehicleRentalsMs.Data;
using _3M1LVehicleRentalsMs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace _3M1LVehicleRentalsMs.Controllers
{
    public class HomeController : Controller
    {
        private readonly CustomerDbContext _customerContext;
        private readonly VehicleDbContext _vehicleContext;
        private readonly ReservationDbContext _reservationContext;

        public HomeController(CustomerDbContext customerContext, VehicleDbContext vehicleContext, ReservationDbContext reservationContext)
        {
            _customerContext = customerContext;
            _vehicleContext = vehicleContext;
            _reservationContext = reservationContext;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel
            {
                Customers = await _customerContext.Customers.ToListAsync(),
                Vehicles = await _vehicleContext.Vehicle.ToListAsync(),
                Reservations = await _reservationContext.Reservation.ToListAsync() 
            };

            return View(viewModel);
        }
    }
}