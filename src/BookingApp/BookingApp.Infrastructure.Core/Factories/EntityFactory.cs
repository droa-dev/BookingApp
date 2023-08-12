using BookingApp.Domain.Core.Entities;
using BookingApp.Domain.Core.Enums;
using BookingApp.Domain.Core.Factories;

namespace BookingApp.Infrastructure.Core.Factories
{
    public class EntityFactory : IHotelFactory
    {
        public Hotel NewHotel(string name, City city, string address, int stars, int id = 0, bool active = true)
        {
            return new Hotel { Name = name, City = city, Address = address, Stars = stars, Id = id, Active = active };
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
    }
}
