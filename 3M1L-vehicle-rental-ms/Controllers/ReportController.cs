using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _3M1LVehicleRentalsMs.Data;
using _3M1LVehicleRentalsMs.Models;

namespace _3M1LVehicleRentalsMs.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ReportDbContext reportDbContext;

        public ReportsController(ReportDbContext reportDbContext)
        {
            this.reportDbContext = reportDbContext;
        }

        // GET: Reports
        [HttpGet]
        [Route("Report")]
        public async Task<IActionResult> Index()
        {
            return View(await reportDbContext.Reports.ToListAsync());
        }

        // GET: Reports/Details/5
        [HttpGet]
        [Route("Report/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reports = await reportDbContext.Reports
                .FirstOrDefaultAsync(m => m.ReportId == id);
            if (reports == null)
            {
                return NotFound();
            }

            return View(reports);
        }

        // GET: Reports/Create
        [HttpGet]
        [Route("Report/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reports/Create

        [HttpPost]
        [Route("Report/Create")]
        public async Task<IActionResult> Create([Bind("ReportId")] Reports reports)
        {
            if (ModelState.IsValid)
            {
                reportDbContext.Add(reports);
                await reportDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reports);
        }

        // GET: Reports/Edit/5
        [HttpGet]
        [Route("Report/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reports = await reportDbContext.Reports.FindAsync(id);
            if (reports == null)
            {
                return NotFound();
            }
            return View(reports);
        }

        // POST: Reports/Edit/5
        [HttpPost]
        [Route("Report/Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("ReportId")] Reports reports)
        {
            if (id != reports.ReportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    reportDbContext.Update(reports);
                    await reportDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportsExists(reports.ReportId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reports);
        }

        // GET: Reports/Delete/5
        [HttpGet]
        [Route("Report/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reports = await reportDbContext.Reports
                .FirstOrDefaultAsync(m => m.ReportId == id);
            if (reports == null)
            {
                return NotFound();
            }

            return View(reports);
        }
        private bool ReportsExists(int id)
        {
            return reportDbContext.Reports.Any(e => e.ReportId == id);
        }
    }
}
