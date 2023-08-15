using BookingApp.Application.Core.Features.Rooms.Commands.Create;

namespace BookingApp.Application.Core.Common.Messages.Room
{
    public class CreateRoomMessage
    {
        public CreateRoomCommand CreateRoomCommand { get; set; } = default!;
    }
}
