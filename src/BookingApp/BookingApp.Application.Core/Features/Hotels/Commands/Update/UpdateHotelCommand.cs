using BookingApp.Domain.Core.Enums;
using MediatR;

namespace BookingApp.Application.Core.Features.Hotels.Commands.Update
{
    public class UpdateHotelCommand : IRequest
    {
        public string HotelId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public City City { get; set; }
        public string Address { get; set; } = default!;
        public int Stars { get; set; }
        public bool Active { get; set; }
    }
}
