using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookingApp.Application.Core.Common;
using BookingApp.Domain.Core.Models;
using BookingApp.Domain.Core.Repositories;
using BookingApp.Infrastructure.Core.Extensions;
using MediatR;

namespace BookingApp.Application.Core.Features.Hotels.Queries.GetList
{
    public class GetHotelsQueryHandler : IRequestHandler<GetHotelsQuery, PagedResult<GetHotelsQueryResponse>>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public GetHotelsQueryHandler(IHotelRepository hotelRepository, IRoomRepository roomRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GetHotelsQueryResponse>> Handle(GetHotelsQuery request, CancellationToken cancellationToken)
        {
            var result = await _hotelRepository
                .FindAll()
                .OrderBy($"{request.SortProperty} {request.SortDir}")
                .ProjectTo<GetHotelsQueryResponse>(_mapper.ConfigurationProvider)
                .GetPagedResultAsync(request.PageSize, request.CurrentPage);

            foreach (var item in result.Results)
            {
                var rooms = await _roomRepository.FindAllAsync(c => c.HotelId == item.HotelId.FromHashId());

                if (rooms.Any())
                {
                    item.Rooms!.AddRange(rooms);
                }
            }

            return result;
        }
    }
}
