using BookingApp.Domain.Core.Entities;
using BookingApp.Domain.Core.Repositories;
using BookingApp.Infrastructure.Core.Data;

namespace BookingApp.Infrastructure.Core.Repositories
{
    public sealed class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository(BookingAppDbContext context) : base(context)
        {
        }
    }
}
