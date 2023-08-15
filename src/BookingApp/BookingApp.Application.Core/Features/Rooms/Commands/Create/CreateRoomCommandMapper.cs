using AutoMapper;
using BookingApp.Application.Core.Common;
using BookingApp.Domain.Core.Entities;

namespace BookingApp.Application.Core.Features.Rooms.Commands.Create
{
    public class CreateRoomCommandMapper : Profile
    {
        public CreateRoomCommandMapper()
        {
            CreateMap<CreateRoomCommand, Room>()
                .ForMember(m => m.HotelId,
                            opt => opt.MapFrom(mf => mf.HotelId.FromHashId()));
        }
    }
}
