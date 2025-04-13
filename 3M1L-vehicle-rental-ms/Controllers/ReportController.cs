using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _3M1LVehicleRentalsMs.Data;
using _3M1LVehicleRentalsMs.Models;

namespace _3M1LVehicleRentalsMs.Controllers
{
    public class ReportController : Controller
    {
        private readonly ReportDbContext _context;

        public ReportController(ReportDbContext context)
        {
            _context = context;
        }

        // GET: Report
        public async Task<IActionResult> Index()
        {
            var reportDbContext = _context.Reports.Include(r => r.Admin).Include(r => r.Customer).Include(r => r.Reservation).Include(r => r.Vehicle);
            return View(await reportDbContext.ToListAsync());
        }

        // GET: Report/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reports = await _context.Reports
                .Include(r => r.Admin)
                .Include(r => r.Customer)
                .Include(r => r.Reservation)
                .Include(r => r.Vehicle)
                .FirstOrDefaultAsync(m => m.ReportId == id);
            if (reports == null)
            {
                return NotFound();
            }

            return View(reports);
        }

        // GET: Report/Create
        public IActionResult Create()
        {
            ViewData["AdminID"] = new SelectList(_context.Set<Admin>(), "AdminID", "AdminEmail");
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "CustomerAddress");
            ViewData["ReservationId"] = new SelectList(_context.Set<Reservation>(), "ReservationId", "ReservationId");
            ViewData["VehicleID"] = new SelectList(_context.Set<Vehicle>(), "VehicleID", "VehicleManufacturer");
            return View();
        }

        // POST: Report/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportId,AdminID,CustomerID,ReservationId,VehicleID")] Reports reports)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reports);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminID"] = new SelectList(_context.Set<Admin>(), "AdminID", "AdminEmail", reports.AdminID);
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "CustomerAddress", reports.CustomerID);
            ViewData["ReservationId"] = new SelectList(_context.Set<Reservation>(), "ReservationId", "ReservationId", reports.ReservationId);
            ViewData["VehicleID"] = new SelectList(_context.Set<Vehicle>(), "VehicleID", "VehicleManufacturer", reports.VehicleID);
            return View(reports);
        }

        // GET: Report/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reports = await _context.Reports.FindAsync(id);
            if (reports == null)
            {
                return NotFound();
            }
            ViewData["AdminID"] = new SelectList(_context.Set<Admin>(), "AdminID", "AdminEmail", reports.AdminID);
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "CustomerAddress", reports.CustomerID);
            ViewData["ReservationId"] = new SelectList(_context.Set<Reservation>(), "ReservationId", "ReservationId", reports.ReservationId);
            ViewData["VehicleID"] = new SelectList(_context.Set<Vehicle>(), "VehicleID", "VehicleManufacturer", reports.VehicleID);
            return View(reports);
        }

        // POST: Report/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReportId,AdminID,CustomerID,ReservationId,VehicleID")] Reports reports)
        {
            if (id != reports.ReportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reports);
                    await _context.SaveChangesAsync();
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
            ViewData["AdminID"] = new SelectList(_context.Set<Admin>(), "AdminID", "AdminEmail", reports.AdminID);
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "CustomerAddress", reports.CustomerID);
            ViewData["ReservationId"] = new SelectList(_context.Set<Reservation>(), "ReservationId", "ReservationId", reports.ReservationId);
            ViewData["VehicleID"] = new SelectList(_context.Set<Vehicle>(), "VehicleID", "VehicleManufacturer", reports.VehicleID);
            return View(reports);
        }

        // GET: Report/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reports = await _context.Reports
                .Include(r => r.Admin)
                .Include(r => r.Customer)
                .Include(r => r.Reservation)
                .Include(r => r.Vehicle)
                .FirstOrDefaultAsync(m => m.ReportId == id);
            if (reports == null)
            {
                return NotFound();
            }

            return View(reports);
        }

        // POST: Report/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reports = await _context.Reports.FindAsync(id);
            if (reports != null)
            {
                _context.Reports.Remove(reports);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportsExists(int id)
        {
            return _context.Reports.Any(e => e.ReportId == id);
        }
    }
}
