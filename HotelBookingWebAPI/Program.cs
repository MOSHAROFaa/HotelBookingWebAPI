using HotelBookingWebAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Database Context Dependency Injection 

var dbHost = "localhost";
var dbName = "hotelbookingdb";
var dbPassword = "123";


var connectionString = $"server={dbHost};database={dbName};user=root;password={dbPassword}";
builder.Services.AddDbContext<BookingDBContext>(options => options.UseMySQL(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
