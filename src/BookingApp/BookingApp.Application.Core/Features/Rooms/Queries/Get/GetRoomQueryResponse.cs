using BookingApp.Domain.Core.Enums;

namespace BookingApp.Application.Core.Features.Rooms.Queries.Get
{
    public class GetRoomQueryResponse
    {
        public string Id { get; set; } = default!;
        public int Capacity { get; set; }
        public RoomType RoomType { get; set; }
        public decimal BaseCost { get; set; }
        public decimal TaxesCost { get; set; }
        public string HotelId { get; set; } = default!;
        public bool Enabled { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModifiedByAt { get; set; }
    }
}
