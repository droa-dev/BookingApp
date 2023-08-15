using BookingApp.Application.Core.Features.Hotels.Commands.Update;

namespace BookingApp.Application.Core.Common.Messages.Hotel
{
    public class UpdateHotelMessage
    {
        public UpdateHotelCommand UpdateHotelCommand { get; set; } = default!;
    }
}
