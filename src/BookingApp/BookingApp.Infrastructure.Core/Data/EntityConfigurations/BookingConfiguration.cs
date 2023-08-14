using BookingApp.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingApp.Infrastructure.Core.Data.EntityConfigurations
{
    public static class BookingConfiguration
    {
        public static void Configure(EntityTypeBuilder<Booking> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Booking", "dbo");

            builder.HasKey(x => x.Id);

            builder
                .HasMany(p => p.Rooms)
                .WithMany(p => p.Bookings)
                .UsingEntity<BookingRoom>();

            builder.HasOne(p => p.Hotel)
                .WithMany(h => h.Bookings)
                .HasForeignKey(p => p.HotelId);

            builder.Property(p => p.FeedingType).IsRequired();
            builder.Property(p => p.StartDate).IsRequired();
            builder.Property(p => p.EndDate).IsRequired();
            builder.Property(p => p.Active).IsRequired();
        }
    }
}
