using AutoMapper;
using BookingApp.Application.Core.Common;
using BookingApp.Domain.Core.Entities;

namespace BookingApp.Application.Core.Features.Bookings.Queries.GetList
{
    public class GetBookingsQueryMapper : Profile
    {
        public GetBookingsQueryMapper()
        {
            CreateMap<Booking, GetBookingsQueryResponse>()
                .ForMember(m => m.HotelId,
                opt => opt.MapFrom(mf => mf.HotelId.ToHashId()))
                .ForMember(
                m => m.BookingRooms,
                opt => opt.MapFrom(mf => mf.Rooms));

            CreateMap<Room, BookingRoomList>()
                .ForMember(
                m => m.Id,
                opt => opt.MapFrom(mf => mf.Id.ToHashId()));
        }
    }
}
