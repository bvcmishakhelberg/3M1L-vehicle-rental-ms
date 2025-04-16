using _3M1L_vehicle_rental_ms.Data;
using _3M1L_vehicle_rental_ms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _3M1L_vehicle_rental_ms.Controllers
{
    public class HomeController : Controller
    {
        private readonly RentalDbContext _context;

        public HomeController(RentalDbContext context)
        {
            this._context = context;
        }



        [HttpGet]
        [Route("/")]
        public async Task<IActionResult> Index()
        {

                var viewModel = new HomeViewModel
                {
                    Customers = await _context.Customers.ToListAsync(),
                    Vehicles = await _context.Vehicles.ToListAsync(),
                    Reservations = await _context.Reservations.ToListAsync()
                };

                return View(viewModel);

        }

        //[HttpGet]
        //[Route("/")]
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
