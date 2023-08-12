using BookingApp.Domain.Core.Enums;
using BookingApp.Domain.Core.Repositories;

namespace BookingApp.Domain.Core.Entities
{
    public class Booking : IEntityBase
    {
        public Booking() { }

        public Booking(int id, IList<BookingRoom> bookingRooms, ICollection<Guest> guests, FeedingType feedingType, DateTime startDate, DateTime endDate)
        {
            this.Id = id;
            this.BookingRooms = bookingRooms;
            this.Guests = guests;
            this.FeedingType = feedingType;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public int Id { get; set; }        
        public ICollection<Guest> Guests { get; set; }
        public FeedingType FeedingType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IList<BookingRoom> BookingRooms { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModifiedByAt { get; set; }
    }
}
