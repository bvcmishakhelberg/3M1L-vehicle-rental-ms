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
    public class VehicleController : Controller
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public VehicleController(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }

        // GET: Vehicle
        [HttpGet]
        [Route("Vehicle")]
        public async Task<IActionResult> Index()
        {
            return View(await _vehicleDbContext.Vehicle.ToListAsync());
        }

        // GET: Vehicle/Details/5
        [HttpGet]
        [Route("Vehicle/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _vehicleDbContext.Vehicle
                .FirstOrDefaultAsync(m => m.VehicleID == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicle/Create
        [HttpGet]
        [Route("Vehicle/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicle/Create
        [HttpPost]
        [Route("Vehicle/Create")]
        public async Task<IActionResult> Create([Bind("VehicleID,VehicleManufacturer,VehicleModel,VehicleYear,VehicleAvailability,VehicleStatus")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _vehicleDbContext.Add(vehicle);
                await _vehicleDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vehicle/Edit/5
        [HttpGet]
        [Route("Vehicle/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _vehicleDbContext.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicle/Edit/5
        [HttpPost]
        [Route("Vehicle/Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleID,VehicleManufacturer,VehicleModel,VehicleYear,VehicleAvailability,VehicleStatus")] Vehicle vehicle)
        {
            if (id != vehicle.VehicleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _vehicleDbContext.Update(vehicle);
                    await _vehicleDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.VehicleID))
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
            return View(vehicle);
        }

        // GET: Vehicle/Delete/5
        [HttpGet]
        [Route("Vehicle/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _vehicleDbContext.Vehicle
                .FirstOrDefaultAsync(m => m.VehicleID == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }


        private bool VehicleExists(int id)
        {
            return _vehicleDbContext.Vehicle.Any(e => e.VehicleID == id);
        }
    }
}
