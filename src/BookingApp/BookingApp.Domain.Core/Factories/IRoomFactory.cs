using BookingApp.Domain.Core.Entities;
using BookingApp.Domain.Core.Enums;

namespace BookingApp.Domain.Core.Factories
{
    public interface IRoomFactory
    {
        Room NewRoom(int capacity, RoomType roomType, decimal baseCost, decimal taxesCost, int hotelId, int id = 0, bool enabled = true);
        Room UpdateRoom(Room currentRoom, Room updatedRoom);
    }
}
