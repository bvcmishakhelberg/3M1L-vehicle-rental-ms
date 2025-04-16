using _3M1L_vehicle_rental_ms.Models;
using Microsoft.EntityFrameworkCore;

namespace _3M1L_vehicle_rental_ms.Data
{
    public class RentalDbContext : DbContext
    {
        public RentalDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Reservation entity (ensure these are still as you want them)
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.CustomerInfo)
                .WithMany()
                .HasForeignKey(r => r.CustomerInfoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.VehicleInfo)
                .WithMany()
                .HasForeignKey(r => r.VehicleInfoId)
                .OnDelete(DeleteBehavior.NoAction);

            //// Explicitly configure the Report entity and its foreign keys with NoAction
            //modelBuilder.Entity<Report>()
            //    .HasOne(r => r.Customer)
            //    .WithMany()
            //    .HasForeignKey(r => r.CustomerID)
            //    .OnDelete(DeleteBehavior.NoAction); // Force NoAction

            //modelBuilder.Entity<Report>()
            //    .HasOne(r => r.Reservation)
            //    .WithMany()
            //    .HasForeignKey(r => r.ReservationId)
            //    .OnDelete(DeleteBehavior.NoAction); // Force NoAction

            //modelBuilder.Entity<Report>()
            //    .HasOne(r => r.Vehicle)
            //    .WithMany()
            //    .HasForeignKey(r => r.VehicleID)
            //    .OnDelete(DeleteBehavior.NoAction); // Force NoAction

            //base.OnModelCreating(modelBuilder);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
