using AutoMapper;
using BookingApp.Domain.Core.Entities;

namespace BookingApp.Application.Core.Features.Hotels.Commands.Create
{
    public class CreateHotelCommandMapper : Profile
    {
        public CreateHotelCommandMapper() => CreateMap<CreateHotelCommand, Hotel>();
    }
}
