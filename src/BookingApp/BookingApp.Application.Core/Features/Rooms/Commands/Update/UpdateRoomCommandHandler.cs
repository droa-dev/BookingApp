using BookingApp.Application.Core.Common;
using BookingApp.Application.Core.Common.Exceptions;
using BookingApp.Domain.Core.Entities;
using BookingApp.Domain.Core.Repositories;
using BookingApp.Infrastructure.Core.Factories;
using MediatR;

namespace BookingApp.Application.Core.Features.Rooms.Commands.Update
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly EntityFactory _entityFactory;

        public UpdateRoomCommandHandler(IRoomRepository roomRepository, EntityFactory entityFactory)
        {
            _roomRepository = roomRepository;
            _entityFactory = entityFactory;
        }

        public async Task Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var roomId = request.RoomId.FromHashId();
            IEntityBase room = await _roomRepository.GetByIdAsync(roomId)
                ?? throw new NotFoundException(nameof(Room), roomId);

            if (room is Room baseRoom)
            {
                Room roomForUpdate = _entityFactory.NewRoom(
                    request.Capacity, request.RoomType, request.BaseCost, request.TaxesCost,
                    request.HotelId.FromHashId(), roomId, request.Enabled);

                var updatedRoom = _entityFactory.UpdateRoom(baseRoom, roomForUpdate);

                await _roomRepository.UpdateAsync(updatedRoom);
            }
        }
    }
}
