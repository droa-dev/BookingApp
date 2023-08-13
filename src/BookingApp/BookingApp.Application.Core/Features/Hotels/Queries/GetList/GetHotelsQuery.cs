using BookingApp.Domain.Core.Models;
using MediatR;

namespace BookingApp.Application.Core.Features.Hotels.Queries.GetList
{
    public class GetHotelsQuery : IRequest<PagedResult<GetHotelsQueryResponse>>
    {
        public string? SortDir { get; set; }
        public string? SortProperty { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
