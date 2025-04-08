using _3M1L_vehicle_rental_ms.Models;
using _3M1L_vehicle_rental_ms.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _3M1L_vehicle_rental_ms.Controllers
{
    public class VehicleController : Controller
    {
        private readonly RentalDbContext rentalDbContext;


        public VehicleController(RentalDbContext rentalDbContext)
        {
            this.rentalDbContext = rentalDbContext;
        }

        // Get all Vehicles
        [HttpGet]
        [Route("Vehicle")]
        public async Task<IActionResult> Index()
        {
            var Vehicles = await rentalDbContext.Vehicles.ToListAsync();
            return View(Vehicles);
        }

        // Get one vehicle
        [HttpGet]
        [Route("Vehicle/Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var vehicle = await rentalDbContext.Vehicles.FirstOrDefaultAsync(a => a.VehicleID == id);
            return View(vehicle);
        }

        // Get the Add.cshtml page
        [HttpGet]
        [Route("Vehicle/Add")]
        public IActionResult Add()
        {
            return View();
        }

        // Create a new vehicle
        [HttpPost]
        [Route("Vehicle/Add")]
        public async Task<IActionResult> Add(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                var newvehicle = new Vehicle()
                {
                    VehicleManufacturer= vehicle.VehicleManufacturer,
                    VehicleModel = vehicle.VehicleModel,
                    VehicleYear = vehicle.VehicleYear,
                    VehicleAvailability = vehicle.VehicleAvailability,
                    VehicleStatus = vehicle.VehicleStatus,
                };
                await rentalDbContext.Vehicles.AddAsync(newvehicle);
                await rentalDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // Get Edit.cshtml page
        [HttpGet]
        [Route("Vehicle/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await rentalDbContext.Vehicles.FirstOrDefaultAsync(a => a.VehicleID == id);
            return View(vehicle);
        }
        
        // Edit one vehicle
        [HttpPost]
        [Route("Vehicle/Edit/{id}")]
        public async Task<IActionResult> Edit(Vehicle NewVehicle)
        {
            if (ModelState.IsValid)
            {
                var vehicle = await rentalDbContext.Vehicles.FindAsync(NewVehicle.VehicleID);
                if (vehicle != null)
                {
                    vehicle.VehicleManufacturer = NewVehicle.VehicleManufacturer;
                    vehicle.VehicleModel = NewVehicle.VehicleModel;
                    vehicle.VehicleYear = NewVehicle.VehicleYear;
                    vehicle.VehicleAvailability = NewVehicle.VehicleAvailability;
                    vehicle.VehicleStatus = NewVehicle.VehicleStatus;
                    await rentalDbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                
            }
            return View(NewVehicle);
        }

        // Delete
        [HttpGet]
        [Route("Vehicle/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await rentalDbContext.Vehicles.FindAsync(id);
            if (vehicle != null)
            {
                rentalDbContext.Vehicles.Remove(vehicle);
                await rentalDbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
