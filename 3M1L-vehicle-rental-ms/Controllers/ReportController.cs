using _3M1L_vehicle_rental_ms.Models;
using _3M1L_vehicle_rental_ms.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _3M1L_vehicle_rental_ms.Controllers
{
    public class ReportsController : Controller
    {
        private readonly RentalDbContext reportDbContext;

        public ReportsController(RentalDbContext reportDbContext)
        {
            this.reportDbContext = reportDbContext;
        }

        // GET: Reports
        [HttpGet]
        [Route("Report")]
        public async Task<IActionResult> Index()
        {

            var viewModel = new HomeViewModel
            {
                Customers = await reportDbContext.Customers.ToListAsync(),
                Vehicles = await reportDbContext.Vehicles.ToListAsync(),
                Reservations = await reportDbContext.Reservations.ToListAsync()
            };

            return View("~/Views/Report/Index.cshtml", viewModel);

        }

    }
}
