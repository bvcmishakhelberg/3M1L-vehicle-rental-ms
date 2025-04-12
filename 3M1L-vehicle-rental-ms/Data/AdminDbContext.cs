using _3M1LVehicleRentalsMs.Models;
using Microsoft.EntityFrameworkCore;



namespace _3M1LVehicleRentalsMs.Data
{
    public class AdminDbContext:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        {
            
        }
    }
}
