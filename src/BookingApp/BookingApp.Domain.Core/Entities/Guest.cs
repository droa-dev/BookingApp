using BookingApp.Domain.Core.Enums;
using BookingApp.Domain.Core.Repositories;

namespace BookingApp.Domain.Core.Entities
{
    public class Guest : IEntityBase
    {
        public Guest() { }

        public Guest(
            int id, string firstName, string lastName, DateTime birthDate,
            IdentificationType identificationType, string identification,
            string email, string phone)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.IdentificationType = identificationType;
            this.Identification = identification;
            this.Email = email;
            this.Phone = phone;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public IdentificationType IdentificationType { get; set; }
        public string Identification { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastModifiedByAt { get; set; }
    }
}
