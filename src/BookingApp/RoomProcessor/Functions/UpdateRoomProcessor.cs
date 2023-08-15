using BookingApp.Application.Core.Common.Messages.Room;
using BookingApp.Application.Core.Features.Rooms.Commands.Update;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading.Tasks;

namespace RoomProcessor.Functions
{
    public class UpdateRoomProcessor
    {
        private readonly IMediator _mediator;

        public UpdateRoomProcessor(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("UpdateRoomProcessor")]
        public async Task Run([QueueTrigger("new-update-room", Connection = "StorageAccount")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"New message incoming {myQueueItem}");
            log.LogInformation("Processing...");

            var message = JsonSerializer.Deserialize<UpdateRoomMessage>(myQueueItem);

            await _mediator.Send(new UpdateRoomCommand
            {
                RoomId = message.UpdateRoomCommand.RoomId,
                HotelId = message.UpdateRoomCommand.HotelId,
                BaseCost = message.UpdateRoomCommand.BaseCost,
                Capacity = message.UpdateRoomCommand.Capacity,
                Enabled = message.UpdateRoomCommand.Enabled,
                RoomType = message.UpdateRoomCommand.RoomType,
                TaxesCost = message.UpdateRoomCommand.TaxesCost
            });

            log.LogInformation("Room Updated!");
        }
    }
}
