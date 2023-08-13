using BookingApp.Domain.Core.Entities;
using BookingApp.Domain.Core.Enums;

namespace BookingApp.Domain.Core.Factories
{
    public interface IBookingFactory
    {
        Booking NewBooking(FeedingType feedingType, DateTime startDate, DateTime endDate, int id = 0, bool active = true);
    }
}
