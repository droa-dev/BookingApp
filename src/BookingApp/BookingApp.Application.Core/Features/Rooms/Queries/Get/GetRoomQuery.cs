using MediatR;

namespace BookingApp.Application.Core.Features.Rooms.Queries.Get
{
    public class GetRoomQuery : IRequest<GetRoomQueryResponse>
    {
        public string RoomId { get; set; }
    }
}
