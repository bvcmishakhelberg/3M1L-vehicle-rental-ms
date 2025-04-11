using _3M1L_vehicle_rental_ms.Models;
using Microsoft.EntityFrameworkCore;

namespace _3M1L_vehicle_rental_ms.Data
{
    public class ReservationDbContext:DbContext
    {
        public ReservationDbContext(DbContextOptions<ReservationDbContext> options) : base(options)
        {

        }
        public DbSet<_3M1L_vehicle_rental_ms.Models.Reservation> Reservation { get; set; } = default!;
    }
}
