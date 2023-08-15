using BookingApp.Application.Core.Common.Messages.Hotel;
using BookingApp.Application.Core.Features.Hotels.Commands.Update;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading.Tasks;

namespace HotelProcessor.Functions
{
    public class UpdateHotelProcessor
    {
        private readonly IMediator _mediator;

        public UpdateHotelProcessor(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("UpdateHotelProcessor")]
        public async Task Run([QueueTrigger("new-updatehotel", Connection = "QueueStorage")] string myQueueItem, ILogger logger)
        {
            logger.LogInformation($"New message incoming {myQueueItem}");
            logger.LogInformation("Processing...");

            var message = JsonSerializer.Deserialize<UpdateHotelMessage>(myQueueItem);

            await _mediator.Send(new UpdateHotelCommand
            {
                HotelId = message.UpdateHotelCommand.HotelId,
                Name = message.UpdateHotelCommand.Name,
                City = message.UpdateHotelCommand.City,
                Address = message.UpdateHotelCommand.Address,
                Stars = message.UpdateHotelCommand.Stars,
                Active = message.UpdateHotelCommand.Active
            });

            logger.LogInformation("Hotel Updated!");
        }
    }
}
