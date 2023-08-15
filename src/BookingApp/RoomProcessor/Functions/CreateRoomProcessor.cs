using BookingApp.Application.Core.Common.Messages.Room;
using BookingApp.Application.Core.Features.Rooms.Commands.Create;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading.Tasks;

namespace RoomProcessor.Functions
{
    public class CreateRoomProcessor
    {
        private readonly IMediator _mediator;

        public CreateRoomProcessor(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("CreateRoomProcessor")]
        public async Task Run([QueueTrigger("new-create-room", Connection = "StorageAccount")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"New message incoming {myQueueItem}");
            log.LogInformation("Processing...");

            var message = JsonSerializer.Deserialize<CreateRoomMessage>(myQueueItem);

            await _mediator.Send(new CreateRoomCommand
            {
                HotelId = message.CreateRoomCommand.HotelId,
                BaseCost = message.CreateRoomCommand.BaseCost,
                Capacity = message.CreateRoomCommand.Capacity,
                Enabled = message.CreateRoomCommand.Enabled,
                RoomType = message.CreateRoomCommand.RoomType,
                TaxesCost = message.CreateRoomCommand.TaxesCost
            });

            log.LogInformation("Room Created!");
        }
    }
}
