using BookingApp.Application.Core.Common;
using BookingApp.Application.Core.Common.Exceptions;
using BookingApp.Domain.Core.Entities;
using BookingApp.Domain.Core.Repositories;
using BookingApp.Infrastructure.Core.Factories;
using MediatR;

namespace BookingApp.Application.Core.Features.Hotels.Commands.Update
{
    public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly EntityFactory _entityFactory;

        public UpdateHotelCommandHandler(IHotelRepository hotelRepository, EntityFactory entityFactory)
        {
            _hotelRepository = hotelRepository;
            _entityFactory = entityFactory;
        }

        public async Task Handle(UpdateHotelCommand command, CancellationToken cancellationToken)
        {
            var hotelId = command.HotelId.FromHashId();
            IEntityBase hotel = await _hotelRepository.GetByIdAsync(hotelId) ?? throw new NotFoundException();

            if (hotel is Hotel hotelBase)
            {
                IEntityBase hotelForUpdate = _entityFactory.NewHotel(
                    id: hotelId, name: command.Name, city: command.City,
                    address: command.Address, stars: command.Stars, active: command.Active);

                if (hotelForUpdate is Hotel modifiedHotel)
                {
                    var updatedHotel = _entityFactory.UpdateHotel(hotelBase, modifiedHotel);

                    await _hotelRepository.UpdateAsync(updatedHotel);
                }
            }
        }
    }
}
