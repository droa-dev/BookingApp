using AutoMapper;
using BookingApp.Application.Core.Common;
using BookingApp.Domain.Core.Entities;

namespace BookingApp.Application.Core.Features.Hotels.Queries.Get
{
    public class GetHotelQueryMapper : Profile
    {
        public GetHotelQueryMapper() => CreateMap<Hotel, GetHotelQueryResponse>()
                .ForMember(m => m.HotelId,
                           opt => opt.MapFrom(mf => mf.Id.ToHashId()));
    }
}
