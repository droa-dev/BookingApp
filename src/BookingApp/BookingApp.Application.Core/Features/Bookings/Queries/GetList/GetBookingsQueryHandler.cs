using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookingApp.Application.Core.Common;
using BookingApp.Domain.Core.Models;
using BookingApp.Domain.Core.Repositories;
using BookingApp.Infrastructure.Core.Extensions;
using MediatR;

namespace BookingApp.Application.Core.Features.Bookings.Queries.GetList
{
    public class GetBookingsQueryHandler : IRequestHandler<GetBookingsQuery, PagedResult<GetBookingsQueryResponse>>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IMapper _mapper;

        public GetBookingsQueryHandler(IBookingRepository bookingRepository, IRoomRepository roomRepository,
            IHotelRepository hotelRepository, IGuestRepository guestRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
            _hotelRepository = hotelRepository;
            _guestRepository = guestRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GetBookingsQueryResponse>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookingRepository
                .FindAll()
                .OrderBy($"{request.SortProperty} {request.SortDir}")
                .ProjectTo<GetBookingsQueryResponse>(_mapper.ConfigurationProvider)
                .GetPagedResultAsync(request.PageSize, request.CurrentPage);

            foreach (var item in result.Results)
            {
                var guest = await _guestRepository.FindAllAsync(g => g.BookingId == item.Id.FromHashId());

                if (guest.Any())
                {
                    item.Guests!.AddRange(guest);
                }

                var rooms = await _roomRepository.FindAllAsync(c => c.HotelId == item.HotelId.FromHashId());

                if (rooms.Any())
                {
                    item.BookingRooms!.AddRange(rooms);
                }

                item.Hotel = await _hotelRepository.GetByIdAsync(item.Id.FromHashId());
            }

            return result;

        }
    }
}
