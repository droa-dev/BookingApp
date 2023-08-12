using BookingApp.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookingApp.Infrastructure.Core.Data
{
    public class BookingAppDbContext : DbContext
    {
        public BookingAppDbContext(DbContextOptions<BookingAppDbContext> options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
