using _3M1L_vehicle_rental_ms.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _3M1L_vehicle_rental_ms.Controllers
{
    public class HomeController : Controller
    {
        private readonly RentalDbContext _context;

        public HomeController(RentalDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            var customers = await _context.Customers.ToListAsync();
            var reservations = await _context.Reservations.ToListAsync();
            return View(vehicles);
        }


        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
