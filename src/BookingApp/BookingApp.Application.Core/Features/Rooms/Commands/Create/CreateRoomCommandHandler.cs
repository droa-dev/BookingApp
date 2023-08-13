using AutoMapper;
using BookingApp.Application.Core.Common;
using BookingApp.Application.Core.Common.Exceptions;
using BookingApp.Domain.Core.Entities;
using BookingApp.Domain.Core.Repositories;
using MediatR;

namespace BookingApp.Application.Core.Features.Rooms.Commands.Create
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoomCommandHandler(IRoomRepository roomRepository, IHotelRepository hotelRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _roomRepository = roomRepository;
            _hotelRepository = hotelRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            IEntityBase hotel = await _hotelRepository.GetByIdAsync(request.HotelId.FromHashId())
                                ?? throw new NotFoundException(nameof(Hotel), request.HotelId);

            var newRoom = _mapper.Map<Room>(request);

            await _roomRepository.AddAsync(newRoom);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
