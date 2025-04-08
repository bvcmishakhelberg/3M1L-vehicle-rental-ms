using _3M1L_vehicle_rental_ms.Models;
using Microsoft.EntityFrameworkCore;

namespace _3M1L_vehicle_rental_ms.Data
{
    public class RentalDbContext:DbContext
    {
        public RentalDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Vehicle> Customers { get; set; }
        public DbSet<Vehicle> Reports { get; set; }
    }
}
