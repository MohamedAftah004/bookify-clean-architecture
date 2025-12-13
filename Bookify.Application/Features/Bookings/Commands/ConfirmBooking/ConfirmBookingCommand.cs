using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Features.Bookings.Commands.ConfirmBooking
{
    public record ConfirmBookingCommand(Guid BookingId) : ICommand;

}
