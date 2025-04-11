using _3M1L_vehicle_rental_ms.Models;
using Microsoft.EntityFrameworkCore;

namespace _3M1L_vehicle_rental_ms.Data
{
    public class CustomerDbContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }
    }

}
