using FluentValidation;

namespace BookingApp.Application.Core.Features.Hotels.Commands.Create
{
    public class CreateHotelValidator : AbstractValidator<CreateHotelCommand>
    {
        public CreateHotelValidator()
        {
            RuleFor(i => i.Name).NotEmpty();
            RuleFor(i => i.City).IsInEnum();
            RuleFor(i => i.Address).NotEmpty();
        }
    }
}
