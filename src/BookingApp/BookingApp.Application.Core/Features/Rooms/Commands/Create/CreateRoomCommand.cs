using BookingApp.Domain.Core.Enums;
using MediatR;

namespace BookingApp.Application.Core.Features.Rooms.Commands.Create
{
    public class CreateRoomCommand : IRequest
    {
        public int Capacity { get; set; }
        public RoomType RoomType { get; set; }
        public decimal BaseCost { get; set; }
        public decimal TaxesCost { get; set; }
        public string HotelId { get; set; } = default!;
        public bool Enabled { get; set; }
    }
}
