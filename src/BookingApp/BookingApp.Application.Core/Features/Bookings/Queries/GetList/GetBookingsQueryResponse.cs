using BookingApp.Domain.Core.Entities;
using BookingApp.Domain.Core.Enums;

namespace BookingApp.Application.Core.Features.Bookings.Queries.GetList
{
    public class GetBookingsQueryResponse
    {
        public string Id { get; set; } = default!;
        public List<Guest>? Guests { get; set; }
        public FeedingType FeedingType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
        public List<BookingRoomList>? BookingRooms { get; set; }
        public string HotelId { get; set; } = default!;
        public Hotel? Hotel { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModifiedByAt { get; set; }
    }

    public class BookingRoomList
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
