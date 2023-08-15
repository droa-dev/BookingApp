using BookingApp.Application.Core.Features.Hotels.Commands.Create;

namespace BookingApp.Application.Core.Common.Messages.Hotel
{
    public class CreateHotelMessage
    {
        public CreateHotelCommand CreateHotelCommand { get; set; } = default!;
    }
}
