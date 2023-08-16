using BookingApp.Application.Core.Common.Messages.Booking;
using BookingApp.Application.Core.Features.Bookings.Commands.Create;
using BookingApp.Application.Core.Features.Bookings.Queries.GetList;
using BookingApp.Domain.Core.Models;
using BookingApp.Domain.Core.Services;
using BookingApp.WebApi.Modules.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.WebApi.Controllers
{
    /// <summary>
    ///     Bookings.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IQueuesService _queuesService;

        public BookingController(IMediator mediator, IQueuesService queuesService)
        {
            _mediator = mediator;
            _queuesService = queuesService;
        }

        /// <summary>
        /// Consulta las reservaciones
        /// </summary>
        /// <response code="200">Bookings found.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Not found.</response>
        /// <param name="query">get Bookings query.</param>        
        /// <returns>reservaciones encontradas</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<GetBookingsQueryResponse>))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Get))]
        public async Task<PagedResult<GetBookingsQueryResponse>> GetBookings([FromQuery] GetBookingsQuery query)
        {
            return await _mediator.Send(query);
        }

        /// <summary>
        /// Crear una reservacion
        /// </summary>
        /// <response code="200">Booking creado.</response>
        /// <response code="400">Bad request.</response>        
        /// <param name="command">create Booking command.</param>        
        /// <returns>comando reservacion creado</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Post))]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingCommand command)
        {
            await _queuesService.QueueAsync("new-create-booking", new CreateBookingMessage
            {
                CreateBookingCommand = command
            });

            return Created(string.Empty, "create command successfully received");
        }
    }
}
