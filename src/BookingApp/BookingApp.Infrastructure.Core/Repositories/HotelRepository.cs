using BookingApp.Domain.Core.Entities;
using BookingApp.Domain.Core.Repositories;
using BookingApp.Infrastructure.Core.Data;

namespace BookingApp.Infrastructure.Core.Repositories
{
    public sealed class HotelRepository : RepositoryBase<Hotel>, IHotelRepository
    {
        public HotelRepository(BookingAppDbContext context) : base(context)
        {
        }
    }
}
