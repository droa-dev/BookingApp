using BookingApp.Domain.Core.Models;
using MediatR;

namespace BookingApp.Application.Core.Features.Bookings.Queries.GetList
{
    public class GetBookingsQuery : IRequest<PagedResult<GetBookingsQueryResponse>>
    {
        public string? SortDir { get; set; }
        public string? SortProperty { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
