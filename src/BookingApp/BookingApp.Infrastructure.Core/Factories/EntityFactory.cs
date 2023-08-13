using BookingApp.Domain.Core.Entities;
using BookingApp.Domain.Core.Enums;
using BookingApp.Domain.Core.Factories;

namespace BookingApp.Infrastructure.Core.Factories
{
    public class EntityFactory : IHotelFactory, IRoomFactory, IBookingFactory
    {
        public Booking NewBooking(FeedingType feedingType, DateTime startDate, DateTime endDate, int id = 0, bool active = true)
        {
            return new Booking(id: id, feedingType, startDate, endDate, active);
        }

        public Hotel NewHotel(string name, City city, string address, int stars, int id = 0, bool active = true)
        {
            return new Hotel { Name = name, City = city, Address = address, Stars = stars, Id = id, Active = active };
        }

        public Room NewRoom(int capacity, RoomType roomType, decimal baseCost, decimal taxesCost, int hotelId, int id = 0, bool enabled = true)
        {
            return new Room(id, capacity, roomType, baseCost, taxesCost, hotelId, enabled);
        }

        public Hotel UpdateHotel(Hotel currentHotel, Hotel updatedHotel)
        {
            return new Hotel(
                id: currentHotel.Id,
                name: currentHotel.Name.Equals(updatedHotel.Name) ? currentHotel.Name : updatedHotel.Name,
                city: currentHotel.City.Equals(updatedHotel.City) ? currentHotel.City : updatedHotel.City,
                address: currentHotel.Address.Equals(updatedHotel.Address) ? currentHotel.Address : updatedHotel.Address,
                stars: currentHotel.Stars.Equals(updatedHotel.Stars) ? currentHotel.Stars : updatedHotel.Stars,
                active: updatedHotel.Active
                );
        }

        public Room UpdateRoom(Room currentRoom, Room updatedRoom)
        {
            return new Room(
                id: currentRoom.Id,
                capacity: currentRoom.Capacity.Equals(updatedRoom.Capacity) ? currentRoom.Capacity : updatedRoom.Capacity,
                roomType: currentRoom.RoomType.Equals(updatedRoom.RoomType) ? currentRoom.RoomType : updatedRoom.RoomType,
                baseCost: currentRoom.BaseCost.Equals(updatedRoom.BaseCost) ? currentRoom.BaseCost : updatedRoom.BaseCost,
                taxesCost: currentRoom.TaxesCost.Equals(updatedRoom.TaxesCost) ? currentRoom.TaxesCost : updatedRoom.TaxesCost,
                hotelId: currentRoom.HotelId.Equals(updatedRoom.HotelId) ? currentRoom.HotelId : updatedRoom.HotelId,
                enabled: updatedRoom.Enabled);
        }
    }
}
