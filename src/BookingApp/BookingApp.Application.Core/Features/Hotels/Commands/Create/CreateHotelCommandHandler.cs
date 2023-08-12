using AutoMapper;
using BookingApp.Domain.Core.Entities;
using BookingApp.Domain.Core.Repositories;
using MediatR;

namespace BookingApp.Application.Core.Features.Hotels.Commands.Create
{
    public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateHotelCommandHandler(IHotelRepository hotelRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateHotelCommand command, CancellationToken cancellationToken)
        {
            var newHotel = _mapper.Map<Hotel>(command);

            await _hotelRepository.AddAsync(newHotel);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
