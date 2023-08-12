using FluentValidation;

namespace BookingApp.Application.Core.Features.Hotels.Commands.Update
{
    public class UpdateHotelValidator : AbstractValidator<UpdateHotelCommand>
    {
        public UpdateHotelValidator()
        {
            RuleFor(i => i.HotelId).NotNull().NotEmpty();
            RuleFor(i => i.Name).NotNull().NotEmpty();
            RuleFor(i => i.City).IsInEnum();
            RuleFor(i => i.Address).NotNull().NotEmpty();
            RuleFor(i => i.Active).NotNull();
        }
    }
}
