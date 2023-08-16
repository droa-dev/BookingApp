using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookingApp.Domain.Core.Models;
using BookingApp.Domain.Core.Repositories;
using BookingApp.Infrastructure.Core.Extensions;
using MediatR;

namespace BookingApp.Application.Core.Features.Bookings.Queries.GetList
{
    public class GetBookingsQueryHandler : IRequestHandler<GetBookingsQuery, PagedResult<GetBookingsQueryResponse>>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public GetBookingsQueryHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<GetBookingsQueryResponse>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
        {
            return await _bookingRepository
                .FindAll()
                .OrderBy($"{request.SortProperty} {request.SortDir}")
                .ProjectTo<GetBookingsQueryResponse>(_mapper.ConfigurationProvider)
                .GetPagedResultAsync(request.PageSize, request.CurrentPage);
        }
    }
}
