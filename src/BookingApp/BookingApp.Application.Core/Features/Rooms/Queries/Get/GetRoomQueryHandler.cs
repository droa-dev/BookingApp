using AutoMapper;
using BookingApp.Application.Core.Common;
using BookingApp.Application.Core.Common.Exceptions;
using BookingApp.Domain.Core.Entities;
using BookingApp.Domain.Core.Repositories;
using MediatR;

namespace BookingApp.Application.Core.Features.Rooms.Queries.Get
{
    public class GetRoomQueryHandler : IRequestHandler<GetRoomQuery, GetRoomQueryResponse>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public GetRoomQueryHandler(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<GetRoomQueryResponse> Handle(GetRoomQuery request, CancellationToken cancellationToken)
        {
            var roomId = request.RoomId.FromHashId();
            IEntityBase room = await _roomRepository.GetByIdAsync(roomId)
                ?? throw new NotFoundException(nameof(Room), request.RoomId);

            return _mapper.Map<GetRoomQueryResponse>(room);
        }
    }
}
