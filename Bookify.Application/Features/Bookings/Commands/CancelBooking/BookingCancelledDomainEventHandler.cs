using Bookify.Application.Abstractions.Email;
using Bookify.Domain.Bookings;
using Bookify.Domain.Bookings.Events;
using Bookify.Domain.Users;
using MediatR;

namespace Bookify.Application.Features.Bookings.Commands.CancelBooking
{
    internal sealed class BookingCancelledDomainEventHandler : INotificationHandler<BookingCancelledDomainEvent>
    {

        private readonly IBookingRespository _bookingRespository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public BookingCancelledDomainEventHandler(IBookingRespository bookingRespository, 
            IUserRepository userRepository, 
            IEmailService emailService)
        {
            _bookingRespository = bookingRespository;
            _userRepository = userRepository;
            _emailService = emailService;
        }



        public async Task Handle(BookingCancelledDomainEvent notification, CancellationToken cancellationToken)
        {
            var booking = await _bookingRespository.GetByIdAsync(notification.BookingId , cancellationToken);
            if(booking is null)
            {
                return;
            }

            var user = await _userRepository.GetByIdAsync(booking.UserId, cancellationToken);
            if(user is null)
            {
                return;
            }


            await _emailService.SendAsync(user.Email, "Booking Cancelled", "Your booking has been canceled successfully.");
        }
    }
}
