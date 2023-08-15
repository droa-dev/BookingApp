using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookingApp.Domain.Core.Models;
using BookingApp.Domain.Core.Repositories;
using BookingApp.Infrastructure.Core.Extensions;
using MediatR;

namespace BookingApp.Application.Core.Features.Hotels.Queries.GetList
{
    public class GetHotelsQueryHandler : IRequestHandler<GetHotelsQuery, PagedResult<GetHotelsQueryResponse>>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public GetHotelsQueryHandler(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GetHotelsQueryResponse>> Handle(GetHotelsQuery request, CancellationToken cancellationToken)
        {
            return await _hotelRepository
                 .FindAll()
                 .OrderBy($"{request.SortProperty} {request.SortDir}")
                 .ProjectTo<GetHotelsQueryResponse>(_mapper.ConfigurationProvider)
                 .GetPagedResultAsync(request.PageSize, request.CurrentPage);
        }
    }
}
