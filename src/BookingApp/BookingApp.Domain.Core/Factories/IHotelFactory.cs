using BookingApp.Domain.Core.Entities;
using BookingApp.Domain.Core.Enums;

namespace BookingApp.Domain.Core.Factories
{
    public interface IHotelFactory
    {
        Hotel NewHotel(string name, City city, string address, int stars, int id = 0, bool active = true);
        Hotel UpdateHotel(Hotel currentHotel, Hotel updatedHotel);
    }
}
