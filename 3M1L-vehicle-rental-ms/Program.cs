using _3M1L_vehicle_rental_ms.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RentalDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString")));
var app = builder.Build();

app.MapControllers();
app.Run();
