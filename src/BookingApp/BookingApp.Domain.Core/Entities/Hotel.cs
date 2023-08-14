using BookingApp.Domain.Core.Enums;
using BookingApp.Domain.Core.Repositories;

namespace BookingApp.Domain.Core.Entities
{
    public class Hotel : IEntityBase
    {
        public Hotel() { }

        public Hotel(int id, string name, City city, string address, int stars, bool active)
        {
            this.Id = id;
            this.Name = name;
            this.City = city;
            this.Address = address;
            this.Stars = stars;
            this.Active = active;            
        }

        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public City City { get; set; }
        public string Address { get; set; } = default!;
        public int Stars { get; set; }
        public bool Active { get; set; }
        public ICollection<Room>? Rooms { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModifiedByAt { get; set; }
    }
}
