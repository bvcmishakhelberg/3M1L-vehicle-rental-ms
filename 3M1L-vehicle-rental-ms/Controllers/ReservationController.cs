using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _3M1L_vehicle_rental_ms.Data;
using _3M1L_vehicle_rental_ms.Models;

namespace _3M1L_vehicle_rental_ms.Controllers
{
    public class ReservationController : Controller
    {

        private readonly RentalDbContext _reservationDbContext;

        public ReservationController(RentalDbContext reservationDbContext)
        {
            _reservationDbContext = reservationDbContext;
        }

        // GET: Reservation
        [HttpGet]
        [Route("Reservation")]
        public async Task<IActionResult> Index()
        {
            var reservations = await _reservationDbContext.Reservations.ToListAsync();
            return View(reservations);

        }


        // GET: Reservation/Create
        [HttpGet]
        [Route("Reservation/Create")]
        public IActionResult Create()
        {
            // Fetch customers and create SelectList
            var customers = _reservationDbContext.Customers.ToList();
            ViewBag.CustomerId = new SelectList(customers, "Id", "FirstNameLastName"); // Adjust property names

            // Fetch vehicles and create SelectList
            var vehicles = _reservationDbContext.Vehicles.ToList();
            ViewBag.VehicleId = new SelectList(vehicles, "VehicleID", "VehicleModelFull"); // Adjust property names

            return View();
        }

        // POST: Reservation/Create
        [HttpPost]
        [Route("Reservation/Create")]
        [ValidateAntiForgeryToken] // Important for security
        public async Task<IActionResult> Create([Bind("ReservationId,CustomerInfoId,VehicleInfoId,ReservationDate,ReservationCost")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _reservationDbContext.Reservations.Add(reservation); // Assuming you have a DbSet<Reservation> in your context
                await _reservationDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // If ModelState is invalid, repopulate ViewBag for the view
            var customers = _reservationDbContext.Customers.ToList();
            ViewBag.CustomerId = new SelectList(customers, "Id", "FirstNameLastName", reservation.CustomerInfoId); // Keep selected value

            var vehicles = _reservationDbContext.Vehicles.ToList();
            ViewBag.VehicleId = new SelectList(vehicles, "VehicleID", "VehicleModelFull", reservation.VehicleInfoId); // Keep selected value

            return View(reservation);
        }

        // GET: Reservation/Edit/5
        [HttpGet]
        [Route("Reservation/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _reservationDbContext.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        // POST: Reservation/Edit/5

        [HttpPost]
        [Route("Reservation/Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationId,ReservationDate,ReservationCost")] Reservation reservation)
        {
            if (id != reservation.ReservationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _reservationDbContext.Update(reservation);
                    await _reservationDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (id != reservation.ReservationId)
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
            return View(reservation);
        }

        // GET: Reservation/Delete/5
        [HttpGet]
        [Route("Reservation/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _reservationDbContext.Reservations
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }
    }
}

