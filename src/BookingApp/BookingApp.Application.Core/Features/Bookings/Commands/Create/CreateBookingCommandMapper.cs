using AutoMapper;
using BookingApp.Application.Core.Features.Guests.Commands.Create;

namespace BookingApp.Application.Core.Features.Bookings.Commands.Create
{
    public class CreateBookingCommandMapper : Profile
    {
        public CreateBookingCommandMapper()
        {
            CreateMap<NewBookingGuest, CreateGuestCommand>();
        }
    }
}
