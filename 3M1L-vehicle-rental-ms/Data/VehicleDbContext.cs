using _3M1LVehicleRentalsMs.Models;
using Microsoft.EntityFrameworkCore;

namespace _3M1LVehicleRentalsMs.Data
{
    public class VehicleDbContext: DbContext
    {
        public DbSet<Vehicle> Vehicle { get; set; }
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
        {

        }
   
    }
}
