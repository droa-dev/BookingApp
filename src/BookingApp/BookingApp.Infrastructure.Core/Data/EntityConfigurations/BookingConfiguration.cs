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

            builder.Property(p => p.FeedingType).IsRequired();
            builder.Property(p => p.StartDate).IsRequired();
            builder.Property(p => p.EndDate).IsRequired();
        }
    }
}
