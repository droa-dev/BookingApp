﻿using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly EntityFactory _entityFactory;

        public CreateBookingCommandHandler(IBookingRepository bookingRepository, IMapper mapper, IUnitOfWork unitOfWork, IMediator mediator, EntityFactory entityFactory)
        {
            _bookingRepository = bookingRepository;
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
            Booking booking = _entityFactory.NewBooking(request.FeedingType, request.StartDate, request.EndDate);

            foreach (var room in request.BookingRooms)
            {
                BookingRoom bookingRoom = new() { BookingId = booking.Id, RoomId = room.RoomId.FromHashId() };
                booking.BookingRooms.Add(bookingRoom);
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
