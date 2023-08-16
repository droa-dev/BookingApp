using AutoMapper;
using BookingApp.Application.Core.Common;
using BookingApp.Application.Core.Features.Guests.Commands.Create;
using BookingApp.Domain.Core.Entities;
using BookingApp.Domain.Core.Repositories;
using BookingApp.Infrastructure.Core.Factories;
using MediatR;

namespace BookingApp.Application.Core.Features.Bookings.Commands.Create
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly EntityFactory _entityFactory;

        public CreateBookingCommandHandler(IBookingRepository bookingRepository, IRoomRepository roomRepository, IMapper mapper, IUnitOfWork unitOfWork, IMediator mediator, EntityFactory entityFactory)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _entityFactory = entityFactory;
        }

        public async Task Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            await CreateBookingAsync(request, cancellationToken);
        }

        private async Task<Booking> CreateBookingAsync(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            Booking booking = _entityFactory.NewBooking(request.FeedingType, request.StartDate, request.EndDate, hotelId: request.HotelId.FromHashId());

            foreach (var room in request.BookingRooms)
            {
                Room bookedRoom = await _roomRepository.GetByIdAsyncWithTracking(room.RoomId.FromHashId());
                booking.Rooms.Add(bookedRoom);
            }

            await _bookingRepository.AddAsync(booking);
            await _unitOfWork.Save(cancellationToken);

            await AsignGuestsToBookingAsync(booking.Id, request.Guests);

            return booking;
        }

        private async Task AsignGuestsToBookingAsync(int id, List<NewBookingGuest> guests)
        {
            foreach (var guest in guests)
            {
                var newGuestCommand = _mapper.Map<CreateGuestCommand>(guest);
                newGuestCommand.BookingId = id.ToHashId();

                await _mediator.Send(newGuestCommand);
            }
        }
    }
}
