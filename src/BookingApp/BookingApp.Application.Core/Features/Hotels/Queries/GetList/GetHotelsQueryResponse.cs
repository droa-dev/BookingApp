using BookingApp.Domain.Core.Entities;
using BookingApp.Domain.Core.Enums;

namespace BookingApp.Application.Core.Features.Hotels.Queries.GetList
{
    public class GetHotelsQueryResponse
    {
        public string HotelId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public City City { get; set; }
        public string Address { get; set; } = default!;
        public int Stars { get; set; }
        public bool Active { get; set; }
        public List<RoomList>? Rooms { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModifiedByAt { get; set; }
    }

    public class RoomList
    {
        public string Id { get; set; } = default!;
        public int Capacity { get; set; }
        public RoomType RoomType { get; set; }
        public decimal BaseCost { get; set; }
        public decimal TaxesCost { get; set; }
        public int HotelId { get; set; }
        public bool Enabled { get; set; }
        public Hotel Hotel { get; set; } = default!;
        public IList<Booking> Bookings { get; set; } = default!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModifiedByAt { get; set; }
    }
}
