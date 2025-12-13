using Bookify.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Application.Features.Bookings.Commands.CancelBooking;

public record CancelBookingCommand(Guid BookingId) : ICommand;
