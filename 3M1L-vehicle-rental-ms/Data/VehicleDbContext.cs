using _3M1L_vehicle_rental_ms.Models;
using Microsoft.EntityFrameworkCore;

namespace _3M1L_vehicle_rental_ms.Data
{
    public class VehicleDbContext: DbContext
    {
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
        {

        }
        public DbSet<_3M1L_vehicle_rental_ms.Models.Vehicle> Vehicle { get; set; } = default!;
    }
}
