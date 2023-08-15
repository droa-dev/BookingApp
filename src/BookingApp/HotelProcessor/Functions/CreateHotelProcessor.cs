using BookingApp.Application.Core.Common.Messages.Hotel;
using BookingApp.Application.Core.Features.Hotels.Commands.Create;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading.Tasks;

namespace HotelProcessor.Functions
{
    public class CreateHotelProcessor
    {        
        private readonly IMediator _mediator;

        public CreateHotelProcessor(IMediator mediator)
        {            
            _mediator = mediator;
        }

        [FunctionName("CreateHotelProcessor")]
        public async Task Run([QueueTrigger("new-createhotel", Connection = "QueueStorage")] string myQueueItem, ILogger logger)
        {
            logger.LogInformation($"New message incoming {myQueueItem}");
            logger.LogInformation("Processing...");

            var message = JsonSerializer.Deserialize<CreateHotelMessage>(myQueueItem);

            await _mediator.Send(new CreateHotelCommand
            {
                Name = message.CreateHotelCommand.Name,
                Address = message.CreateHotelCommand.Address,
                City = message.CreateHotelCommand.City,
                Stars = message.CreateHotelCommand.Stars,
                Active = message.CreateHotelCommand.Active
            });

            logger.LogInformation("Hotel Created!");
        }
    }
}
