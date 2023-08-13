using AutoMapper;
using BookingApp.Domain.Core.Entities;
using BookingApp.Domain.Core.Repositories;
using MediatR;

namespace BookingApp.Application.Core.Features.Guests.Commands.Create
{
    public class CreateGuestCommandHandler : IRequestHandler<CreateGuestCommand>
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateGuestCommandHandler(IGuestRepository guestRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _guestRepository = guestRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateGuestCommand request, CancellationToken cancellationToken)
        {
            var newGuest = _mapper.Map<Guest>(request);

            await _guestRepository.AddAsync(newGuest);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
