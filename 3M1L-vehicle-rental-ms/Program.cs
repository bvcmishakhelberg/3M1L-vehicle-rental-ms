using _3M1L_vehicle_rental_ms.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RentalDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString")));
builder.Services.AddDbContext<AdminDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AdminDbContext")));
builder.Services.AddDbContext<CustomerDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerDbContext")));
builder.Services.AddDbContext<ReportDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ReportDbContext")));
builder.Services.AddDbContext<ReservationDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("ReservationDbContext")));
builder.Services.AddDbContext<VehicleDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("VehicleDbContext")));

var app = builder.Build();

app.MapControllers();
app.Run();
