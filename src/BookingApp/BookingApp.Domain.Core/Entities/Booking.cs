using BookingApp.Domain.Core.Enums;
using BookingApp.Domain.Core.Repositories;

namespace BookingApp.Domain.Core.Entities
{
    public class Booking : IEntityBase
    {
        public Booking() { }

        public Booking(int id, FeedingType feedingType, DateTime startDate, DateTime endDate, int hotelId, bool active)
        {
            Id = id;
            FeedingType = feedingType;
            StartDate = startDate;
            EndDate = endDate;
            HotelId = hotelId;
            Active = active;
        }

        public int Id { get; set; }
        public ICollection<Guest> Guests { get; set; } = new HashSet<Guest>();
        public FeedingType FeedingType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
        public IList<Room> Rooms { get; set; }        
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModifiedByAt { get; set; }
    }
}
