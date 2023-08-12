using BookingApp.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingApp.Infrastructure.Core.Data.EntityConfigurations
{
    public static class HotelConfiguration
    {
        public static void Configure(EntityTypeBuilder<Hotel> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Hotel", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.Active).IsRequired();

        }
    }
}
