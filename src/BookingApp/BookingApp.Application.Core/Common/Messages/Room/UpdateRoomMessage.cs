using BookingApp.Application.Core.Features.Rooms.Commands.Update;

namespace BookingApp.Application.Core.Common.Messages.Room
{
    public class UpdateRoomMessage
    {
        public UpdateRoomCommand UpdateRoomCommand { get; set; } = default!;
    }
}
