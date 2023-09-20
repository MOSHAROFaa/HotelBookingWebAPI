using HotelBookingWebAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;

namespace HotelBookingWebAPI
{
    public class BookingDBContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public BookingDBContext(DbContextOptions<BookingDBContext> options) : base(options)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if(databaseCreator != null)
                {
                    // Create Database if cannot connect
                    if (!databaseCreator.CanConnect())
                    {
                        databaseCreator.Create();
                    }

                    // Create Tables if not tables exist
                    if (!databaseCreator.HasTables())
                    {
                        databaseCreator.CreateTables();
                    }
                }
            
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       // public DbSet<Booking> Bookings { get; set; }
    }
}
