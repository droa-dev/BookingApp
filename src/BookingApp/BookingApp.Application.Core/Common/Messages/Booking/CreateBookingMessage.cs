using BookingApp.Application.Core.Features.Bookings.Commands.Create;

namespace BookingApp.Application.Core.Common.Messages.Booking
{
    public class CreateBookingMessage
    {
        public CreateBookingCommand CreateBookingCommand { get; set; } = default!;
    }
}
