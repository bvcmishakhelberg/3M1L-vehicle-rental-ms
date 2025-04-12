using _3M1L_vehicle_rental_ms.Models;
using Microsoft.EntityFrameworkCore;

namespace _3M1L_vehicle_rental_ms.Data
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
    }

    public class RentalDbContext:DbContext
    {
        public RentalDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Vehicle> Reports { get; set; }
    }
}
