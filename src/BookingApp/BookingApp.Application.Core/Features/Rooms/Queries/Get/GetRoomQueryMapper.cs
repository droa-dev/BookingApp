using AutoMapper;
using BookingApp.Application.Core.Common;
using BookingApp.Domain.Core.Entities;

namespace BookingApp.Application.Core.Features.Rooms.Queries.Get
{
    public class GetRoomQueryMapper : Profile
    {
        public GetRoomQueryMapper()
        {
            CreateMap<Room, GetRoomQueryResponse>()
                .ForMember(
                m => m.Id,
                opt => opt.MapFrom(mf => mf.Id.ToHashId()))
                .ForMember(
                m => m.HotelId,
                opt => opt.MapFrom(mf => mf.HotelId.ToHashId()));
        }
    }
}
