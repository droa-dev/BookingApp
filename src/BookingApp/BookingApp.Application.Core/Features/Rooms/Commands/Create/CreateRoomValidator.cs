using FluentValidation;

namespace BookingApp.Application.Core.Features.Rooms.Commands.Create
{
    public class CreateRoomValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomValidator()
        {
            RuleFor(i => i.Capacity).GreaterThan(0);
            RuleFor(i => i.RoomType).IsInEnum();
            RuleFor(i => i.BaseCost).GreaterThan(0);
            RuleFor(i => i.TaxesCost).GreaterThanOrEqualTo(0);
            RuleFor(i => i.HotelId).NotNull().NotEmpty();
            RuleFor(i => i.Enabled).NotNull();
        }
    }
}
