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
    public class ReservationController : Controller
    {
        private readonly ReservationDbContext _reservationDbContext;

        public ReservationController(ReservationDbContext reservationDbContext)
        {
            _reservationDbContext = reservationDbContext;
        }

        // GET: Reservation
        [HttpGet]
        [Route("Reservation")]
        public async Task<IActionResult> Index()
        {
            var reservations = await _reservationDbContext.Reservation.ToListAsync();
            return View(reservations);

        }

        // GET: Reservation/Details/5
        [HttpGet]
        [Route("Reservation/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _reservationDbContext.Reservation
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservation/Create
        [HttpGet]
        [Route("Reservation/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservation/Create
        [HttpPost]
        [Route("Reservation/Create")]
        public async Task<IActionResult> Create([Bind("ReservationId,ReservationDate,ReservationCost")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _reservationDbContext.Add(reservation);
                await _reservationDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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

            var reservation = await _reservationDbContext.Reservation.FindAsync(id);
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
                    if (!ReservationExists(reservation.ReservationId))
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

            var reservation = await _reservationDbContext.Reservation
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        private bool ReservationExists(int id)
        {
            return _reservationDbContext.Reservation.Any(e => e.ReservationId == id);
        }
    }
}
