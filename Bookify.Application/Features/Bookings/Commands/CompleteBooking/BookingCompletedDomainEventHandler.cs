using Bookify.Application.Abstractions.Email;
using Bookify.Domain.Bookings;
using Bookify.Domain.Bookings.Events;
using Bookify.Domain.Users;
using MediatR;

internal sealed class BookingCompletedDomainEventHandler
    : INotificationHandler<BookingCompletedDomainEvent>
{
    private readonly IUserRepository _userRepository;
    private readonly IBookingRespository _bookingRepository;
    private readonly IEmailService _emailService;

    public BookingCompletedDomainEventHandler(
        IUserRepository userRepository,
        IBookingRespository bookingRepository,
        IEmailService emailService)
    {
        _userRepository = userRepository;
        _bookingRepository = bookingRepository;
        _emailService = emailService;
    }

    public async Task Handle(
        BookingCompletedDomainEvent notification,
        CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository
            .GetByIdAsync(notification.BookingId, cancellationToken);

        if (booking is null) return;

        var user = await _userRepository
            .GetByIdAsync(booking.UserId, cancellationToken);

        if (user is null) return;

        await _emailService.SendAsync(
            user.Email,
            "Thanks for your stay!",
            "Your booking has been completed. Please leave a review.");
    }
}
