using FluentValidation;

namespace BookingApp.Application.Core.Features.Guests.Commands.Create
{
    public class CreateGuestValidator : AbstractValidator<CreateGuestCommand>
    {
        public CreateGuestValidator()
        {
            RuleFor(r => r.FirstName).NotNull().NotEmpty();
            RuleFor(r => r.LastName).NotNull().NotEmpty();
            RuleFor(r => r.BirthDate).NotNull().NotEmpty();
            RuleFor(r => r.FirstName).IsInEnum();
            RuleFor(r => r.Identification).NotNull().NotEmpty();
            RuleFor(r => r.Email).NotNull().NotEmpty();
            RuleFor(r => r.BookingId).NotNull().NotEmpty();
        }
    }
}
