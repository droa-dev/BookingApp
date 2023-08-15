using BookingApp.Application.Core.Common.Messages.Room;
using BookingApp.Application.Core.Features.Rooms.Commands.Create;
using BookingApp.Application.Core.Features.Rooms.Commands.Update;
using BookingApp.Application.Core.Features.Rooms.Queries.Get;
using BookingApp.Domain.Core.Models;
using BookingApp.Domain.Core.Services;
using BookingApp.WebApi.Modules.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.WebApi.Controllers
{
    /// <summary>
    ///     Rooms.
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IQueuesService _queuesService;

        public RoomController(IMediator mediator, IQueuesService queuesService)
        {
            _mediator = mediator;
            _queuesService = queuesService;
        }

        /// <summary>
        /// Consulta un Room por Id
        /// </summary>
        /// <response code="200">Room found.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Not found.</response>
        /// <param name="query">get Room query.</param>        
        /// <returns>Room encontrado</returns>
        [HttpGet("{RoomId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetRoomQueryResponse))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationException))]
        //[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundException))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Get))]
        public async Task<GetRoomQueryResponse> GetRoomById([FromRoute] GetRoomQuery query)
        {
            return await _mediator.Send(query);
        }

        /// <summary>
        /// Crear un Room
        /// </summary>
        /// <response code="200">Room creado.</response>
        /// <response code="400">Bad request.</response>        
        /// <param name="command">create Room command.</param>        
        /// <returns>creado</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationException))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Post))]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomCommand command)
        {
            await _queuesService.QueueAsync("new-create-room", new CreateRoomMessage
            {
                CreateRoomCommand = command
            });

            return Created(string.Empty, "create command successfully received");
        }

        /// <summary>
        /// Actualiza un Room
        /// </summary>
        /// <response code="202">Room actualizado.</response>
        /// <response code="400">Bad request.</response>        
        /// <response code="404">Not found.</response>
        /// <param name="command">update Room command.</param>        
        /// <returns>creado</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(string))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationException))]
        //[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundException))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Update))]
        public async Task<IActionResult> UpdateRoom([FromBody] UpdateRoomCommand command)
        {
            await _queuesService.QueueAsync("new-update-room", new UpdateRoomMessage
            {
                UpdateRoomCommand = command
            });

            return Created(string.Empty, "update command successfully received");
        }
    }
}
