using AutoMapper;
using BookingApp.Application.Core.Common;
using BookingApp.Application.Core.Common.Exceptions;
using BookingApp.Domain.Core.Entities;
using BookingApp.Domain.Core.Repositories;
using MediatR;

namespace BookingApp.Application.Core.Features.Hotels.Queries.Get
{
    public class GetHotelQueryHandler : IRequestHandler<GetHotelQuery, GetHotelQueryResponse>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public GetHotelQueryHandler(IHotelRepository hotelRepository, IRoomRepository roomRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<GetHotelQueryResponse> Handle(GetHotelQuery request, CancellationToken cancellationToken)
        {
            var hotelId = request.HotelId.FromHashId();
            IEntityBase hotel = await _hotelRepository.GetByIdAsync(hotelId)
                ?? throw new NotFoundException(nameof(Hotel), request.HotelId);

            if (hotel is Hotel hotelFound)
            {
                var rooms = await _roomRepository.FindAllAsync(c => c.HotelId == hotelId);

                if (rooms.Any())
                {
                    foreach (var room in rooms)
                    {
                        hotelFound.Rooms!.Add(room);
                    }
                }

                return _mapper.Map<GetHotelQueryResponse>(hotelFound);
            }

            return _mapper.Map<GetHotelQueryResponse>(hotel);
        }
    }
}
