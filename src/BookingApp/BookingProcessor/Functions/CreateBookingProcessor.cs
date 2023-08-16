using BookingApp.Application.Core.Common.Messages.Booking;
using BookingApp.Application.Core.Features.Bookings.Commands.Create;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookingProcessor.Functions
{
    public class CreateBookingProcessor
    {
        private readonly IMediator _mediator;

        public CreateBookingProcessor(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("CreateBookingProcessor")]
        public async Task Run([QueueTrigger("new-create-booking", Connection = "StorageAccount")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"New message incoming {myQueueItem}");
            log.LogInformation("Processing...");

            var message = JsonSerializer.Deserialize<CreateBookingMessage>(myQueueItem).CreateBookingCommand;

            await _mediator.Send(new CreateBookingCommand
            {
                HotelId = message.HotelId,
                EndDate = message.EndDate,
                FeedingType = message.FeedingType,
                BookingRooms = message.BookingRooms,
                Guests = message.Guests,
                StartDate = message.StartDate
            });

            log.LogInformation("Booking Created!");
        }
    }
}
