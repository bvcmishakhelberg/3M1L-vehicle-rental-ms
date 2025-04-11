using _3M1L_vehicle_rental_ms.Models;
using Microsoft.EntityFrameworkCore;



namespace _3M1L_vehicle_rental_ms.Data
{
    public class AdminDbContext:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        {
            
        }
    }
}
