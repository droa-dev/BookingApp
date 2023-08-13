using AutoMapper;
using BookingApp.Application.Core.Common;
using BookingApp.Domain.Core.Entities;

namespace BookingApp.Application.Core.Features.Hotels.Queries.GetList
{
    public class GetHotelsQueryMapper : Profile
    {
        public GetHotelsQueryMapper()
        {
            CreateMap<Hotel, GetHotelsQueryResponse>()
                .ForMember(
                m => m.HotelId,
                opt => opt.MapFrom(mf => mf.Id.ToHashId()));
        }
    }
}
