using AutoMapper;
using BookingApp.Application.Core.Common;
using BookingApp.Domain.Core.Entities;

namespace BookingApp.Application.Core.Features.Guests.Commands.Create
{
    public class CreateGuestCommandMapper : Profile
    {
        public CreateGuestCommandMapper()
        {
            CreateMap<CreateGuestCommand, Guest>()
                .ForMember(m => m.BookingId,
                opt => opt.MapFrom(mf => mf.BookingId.FromHashId()));
        }
    }
}
