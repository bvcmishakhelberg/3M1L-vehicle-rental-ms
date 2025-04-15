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

        //[HttpGet]
        //[Route("/")]
        //public async Task<IActionResult> Index()
        //{

        //    var reports = await _context.Reports
        //        .Include(r => r.Reservation)
        //        .Include(r => r.Customer)
        //        .Include(r => r.Vehicle)
        //        .ToListAsync();

        //    return View(reports);
        //}

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
