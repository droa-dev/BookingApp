using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApp.Domain.Core.Entities
{
    public class BookingRoom
    {
        public int BookingId { get; set; }

        [NotMapped]
        public Booking Booking { get; set; }

        public int RoomId { get; set; }

        [NotMapped]
        public Room Room { get; set; }
    }
}
