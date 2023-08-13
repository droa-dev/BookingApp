using FluentValidation;

namespace BookingApp.Application.Core.Features.Rooms.Commands.Update
{
    public class UpdateRoomValidator : AbstractValidator<UpdateRoomCommand>
    {
        public UpdateRoomValidator()
        {
            RuleFor(i => i.RoomId).NotNull().NotEmpty();
            RuleFor(i => i.HotelId).NotNull().NotEmpty();
            RuleFor(i => i.Capacity).GreaterThan(0);
            RuleFor(i => i.RoomType).IsInEnum();
            RuleFor(i => i.BaseCost).GreaterThan(0);
            RuleFor(i => i.TaxesCost).GreaterThanOrEqualTo(0);
        }
    }
}
