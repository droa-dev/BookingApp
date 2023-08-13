using BookingApp.Domain.Core.Enums;
using BookingApp.Domain.Core.Repositories;

namespace BookingApp.Domain.Core.Entities
{
    public class Room : IEntityBase
    {
        public Room() { }

        public Room(int id, int capacity, RoomType roomType, decimal baseCost, decimal taxesCost, int hotelId, bool enabled)
        {
            Id = id;
            Capacity = capacity;
            RoomType = roomType;
            BaseCost = baseCost;
            TaxesCost = taxesCost;
            HotelId = hotelId;
            Enabled = enabled;
        }

        public int Id { get; set; }
        public int Capacity { get; set; }
        public RoomType RoomType { get; set; }
        public decimal BaseCost { get; set; }
        public decimal TaxesCost { get; set; }
        public int HotelId { get; set; }
        public bool Enabled { get; set; }
        public Hotel Hotel { get; set; }
        public IList<BookingRoom> BookingRooms { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModifiedByAt { get; set; }
    }
}
