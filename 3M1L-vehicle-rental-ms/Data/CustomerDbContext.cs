using _3M1LVehicleRentalsMs.Models;
using Microsoft.EntityFrameworkCore;

namespace _3M1LVehicleRentalsMs.Data
{
    public class CustomerDbContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }
    }

}
