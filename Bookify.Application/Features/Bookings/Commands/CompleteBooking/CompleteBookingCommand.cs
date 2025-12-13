using Bookify.Application.Abstractions.Messaging;

public record CompleteBookingCommand(
    Guid BookingId
) : ICommand;
