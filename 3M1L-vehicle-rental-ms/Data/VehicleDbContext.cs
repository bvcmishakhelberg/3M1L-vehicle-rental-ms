using _3M1LVehicleRentalsMs.Models;
using Microsoft.EntityFrameworkCore;

namespace _3M1LVehicleRentalsMs.Data
{
    public class VehicleDbContext: DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
        {

        }
   
    }
}
