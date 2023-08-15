using BookingApp.Application.Core.Common.Exceptions;
using BookingApp.Application.Core.Common.Messages.Hotel;
using BookingApp.Application.Core.Features.Hotels.Commands.Create;
using BookingApp.Application.Core.Features.Hotels.Queries.Get;
using BookingApp.Application.Core.Features.Hotels.Queries.GetList;
using BookingApp.Domain.Core.Models;
using BookingApp.Domain.Core.Services;
using BookingApp.WebApi.Modules.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.WebApi.Controllers
{
    /// <summary>
    ///     Hoteles.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IQueuesService _queuesService;

        public HotelController(IMediator mediator, IQueuesService queuesService)
        {
            _mediator = mediator;
            _queuesService = queuesService;
        }

        /// <summary>
        /// Consulta los hotels
        /// </summary>
        /// <response code="200">Hotels found.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Not found.</response>
        /// <param name="query">get hotels query.</param>        
        /// <returns>hoteles encontrados</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<GetHotelsQueryResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationException))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundException))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Get))]
        public async Task<PagedResult<GetHotelsQueryResponse>> GetHotels([FromQuery] GetHotelsQuery query)
        {
            return await _mediator.Send(query);
        }

        /// <summary>
        /// Consulta un hotel por Id
        /// </summary>
        /// <response code="200">Hotel found.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Not found.</response>
        /// <param name="query">get hotel query.</param>        
        /// <returns>hotel encontrado</returns>
        [HttpGet("{HotelId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetHotelQueryResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationException))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundException))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Get))]
        public async Task<GetHotelQueryResponse> GetHotelById([FromRoute] GetHotelQuery query)
        {
            return await _mediator.Send(query);
        }

        /// <summary>
        /// Crear un hotel
        /// </summary>
        /// <response code="200">Hotel creado.</response>
        /// <response code="400">Bad request.</response>        
        /// <param name="command">create hotel command.</param>        
        /// <returns>creado</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationException))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Post))]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelCommand command) 
        {
            await _queuesService.QueueAsync("new-createhotel", new CreateHotelMessage
            {
                CreateHotelCommand = command
            });

            return Created(string.Empty, "resource created successfully");
        }
    }
}
