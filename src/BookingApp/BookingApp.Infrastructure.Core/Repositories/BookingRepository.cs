using BookingApp.Domain.Core.Entities;
using BookingApp.Domain.Core.Repositories;
using BookingApp.Infrastructure.Core.Data;

namespace BookingApp.Infrastructure.Core.Repositories
{
    public sealed class BookingRepository : RepositoryBase<Booking>, IBookingRepository
    {
        public BookingRepository(BookingAppDbContext context) : base(context) { }

    }
}
