using _3M1LVehicleRentalsMs.Models;
using Microsoft.EntityFrameworkCore;

namespace _3M1LVehicleRentalsMs.Data
{
    public class ReservationDbContext:DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }
        public ReservationDbContext(DbContextOptions<ReservationDbContext> options) : base(options)
        {

        }

    }
}
