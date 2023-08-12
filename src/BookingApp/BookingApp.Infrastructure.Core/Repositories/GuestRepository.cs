using BookingApp.Domain.Core.Entities;
using BookingApp.Domain.Core.Repositories;
using BookingApp.Infrastructure.Core.Data;

namespace BookingApp.Infrastructure.Core.Repositories
{
    public sealed class GuestRepository : RepositoryBase<Guest>, IGuestRepository
    {
        public GuestRepository(BookingAppDbContext context) : base(context) { }

    }
}
