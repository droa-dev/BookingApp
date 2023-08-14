using FluentValidation;

namespace BookingApp.Application.Core.Features.Bookings.Commands.Create
{
    public class CreateBookingValidator : AbstractValidator<CreateBookingCommand>
    {
        public CreateBookingValidator()
        {
            RuleFor(r => r.Guests).NotEmpty();
            RuleFor(r => r.FeedingType).IsInEnum();
            RuleFor(r => r.StartDate).NotNull().NotEmpty();
            RuleFor(r => r.EndDate).NotNull().NotEmpty();
            RuleFor(r => r.BookingRooms).NotEmpty();
        }
    }
}
