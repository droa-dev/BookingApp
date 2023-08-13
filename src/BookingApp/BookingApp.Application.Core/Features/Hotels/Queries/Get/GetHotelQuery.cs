using MediatR;

namespace BookingApp.Application.Core.Features.Hotels.Queries.Get
{
    public class GetHotelQuery : IRequest<GetHotelQueryResponse>
    {
        public string HotelId { get; set; }
    }
}
