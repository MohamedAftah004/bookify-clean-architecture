using Bookify.Application.Abstractions.Email;
using Bookify.Domain.Bookings;
using Bookify.Domain.Bookings.Events;
using Bookify.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Application.Features.Bookings.Commands.ConfirmBooking
{
    internal sealed class BookingConfirmedDomainEventHandler : INotificationHandler<BookingConfirmedDomainEvent>
    {

        private readonly IUserRepository _userReposiotry;
        private readonly IBookingRespository _bookingRepository;
        private readonly IEmailService _emailService;

        public BookingConfirmedDomainEventHandler(
            IUserRepository userReposiotry,
            IBookingRespository bookingRepository,
            IEmailService emailService)
        {
            _userReposiotry = userReposiotry;
            _bookingRepository = bookingRepository;
            _emailService = emailService;
        }

        public async Task Handle(BookingConfirmedDomainEvent notification, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetByIdAsync(notification.BookingId , cancellationToken);

            if(booking is null)
            {
                return;
            }

            var user = await _userReposiotry.GetByIdAsync(booking.UserId, cancellationToken);
            if (user is null)
            {
                return;
            }

            await _emailService.SendAsync(user.Email, "Booking Confirmed", "Your booking has been confirmed successfully.");
        }
    }
}
