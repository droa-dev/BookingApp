using BookingApp.Domain.Core.Enums;
using BookingApp.Domain.Core.Repositories;

namespace BookingApp.Domain.Core.Entities
{
    public class Room : IEntityBase
    {
        public Room() { }

        public Room(int id, int capacity, RoomType roomType, decimal baseCost, decimal taxesCost, int hotelId)
        {
            this.Id = id;
            this.Capacity = capacity;
            this.RoomType = roomType;
            this.BaseCost = baseCost;
            this.TaxesCost = taxesCost;
            this.HotelId = hotelId;
        }

        public int Id { get; set; }
        public int Capacity { get; set; }
        public RoomType RoomType { get; set; }
        public decimal BaseCost { get; set; }
        public decimal TaxesCost { get; set; }
        public int HotelId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModifiedByAt { get; set; }
    }
}
