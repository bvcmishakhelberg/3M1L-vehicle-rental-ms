using _3M1L_vehicle_rental_ms.Models;
using Microsoft.EntityFrameworkCore;

namespace _3M1L_vehicle_rental_ms.Data
{
    public class ReportDbContext : DbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> options) : base(options)
        {
        }

        public DbSet<Reports> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Cause we have foreign keys with reports

            modelBuilder.Entity<Reports>()
                .HasOne(r => r.Admin)
                .WithMany()
                .HasForeignKey(r => r.AdminID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Reports>()
                .HasOne(r => r.Customer)
                .WithMany()
                .HasForeignKey(r => r.CustomerID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Reports>()
                .HasOne(r => r.Reservation)
                .WithMany()
                .HasForeignKey(r => r.ReservationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Reports>()
                .HasOne(r => r.Vehicle)
                .WithMany()
                .HasForeignKey(r => r.VehicleID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

