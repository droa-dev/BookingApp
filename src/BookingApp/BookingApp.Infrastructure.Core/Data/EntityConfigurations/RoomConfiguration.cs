using BookingApp.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingApp.Infrastructure.Core.Data.EntityConfigurations
{
    public static class RoomConfiguration
    {
        public static void Configure(EntityTypeBuilder<Room> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Room", "dbo");

            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.Hotel)
                .WithOne()
                .HasForeignKey<Room>(p => p.HotelId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Property(p => p.Capacity).IsRequired();
            builder.Property(p => p.RoomType).IsRequired();
            builder.Property(p => p.BaseCost).IsRequired();
            builder.Property(p => p.TaxesCost).IsRequired();

        }
    }
}
