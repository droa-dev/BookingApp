using BookingApp.Domain.Core.Enums;
using MediatR;

namespace BookingApp.Application.Core.Features.Bookings.Commands.Create
{
    public class CreateBookingCommand : IRequest
    {
        public List<NewBookingGuest> Guests { get; set; } = new();
        public FeedingType FeedingType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<NewBookingRoom> BookingRooms { get; set; } = new();
    }

    public class NewBookingGuest
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime BirthDate { get; set; }
        public IdentificationType IdentificationType { get; set; }
        public string Identification { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
    }

    public class NewBookingRoom
    {
        public string RoomId { get; set; } = default!;
    }
}
