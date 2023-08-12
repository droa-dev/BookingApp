using BookingApp.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingApp.Infrastructure.Core.Data.EntityConfigurations
{
    public static class GuestConfiguration
    {
        public static void Configure(EntityTypeBuilder<Guest> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Guest", "dbo");

            builder.HasOne(b => b.Booking)
                   .WithMany(b => b.Guests)
                   .HasForeignKey(b => b.BookingId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(x => x.Id);
            builder.Property(p => p.FirstName).IsRequired();
            builder.Property(p => p.LastName).IsRequired();
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p => p.IdentificationType).IsRequired();
            builder.Property(p => p.Identification).IsRequired();
            builder.Property(p => p.LastName).IsRequired();
        }
    }
}
