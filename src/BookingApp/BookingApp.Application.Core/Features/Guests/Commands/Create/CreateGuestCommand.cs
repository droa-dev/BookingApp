using BookingApp.Domain.Core.Enums;
using MediatR;

namespace BookingApp.Application.Core.Features.Guests.Commands.Create
{
    public class CreateGuestCommand : IRequest
    {        
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime BirthDate { get; set; }
        public IdentificationType IdentificationType { get; set; }
        public string Identification { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string BookingId { get; set; } = default!;
    }
}
