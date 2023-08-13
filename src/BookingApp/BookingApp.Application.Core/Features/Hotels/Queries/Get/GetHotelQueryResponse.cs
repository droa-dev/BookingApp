using BookingApp.Domain.Core.Entities;
using BookingApp.Domain.Core.Enums;

namespace BookingApp.Application.Core.Features.Hotels.Queries.Get
{
    public class GetHotelQueryResponse
    {
        public string HotelId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public City City { get; set; }
        public string Address { get; set; } = default!;
        public int Stars { get; set; }
        public bool Active { get; set; }
        public ICollection<Room>? Rooms { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModifiedByAt { get; set; }
    }
}
