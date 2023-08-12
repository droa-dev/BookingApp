using BookingApp.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingApp.Infrastructure.Core.Data.EntityConfigurations
{
    public static class BookingRoomConfiguration
    {
        public static void Configure(EntityTypeBuilder<BookingRoom> builder)
        {
            builder.ToTable("BookingRoom", "dbo");

            builder.HasKey(br => new { br.BookingId, br.RoomId });

            builder.HasOne(b => b.Booking)
                   .WithMany(br => br.BookingRooms)
                   .HasForeignKey(b => b.BookingId);

            builder.HasOne(r => r.Room)
                   .WithMany(br => br.BookingRooms)
                   .HasForeignKey(r => r.RoomId);

        }
    }
}
