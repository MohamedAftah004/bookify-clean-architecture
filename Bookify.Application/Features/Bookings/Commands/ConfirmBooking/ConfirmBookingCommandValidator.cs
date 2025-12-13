using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Application.Features.Bookings.Commands.ConfirmBooking
{
    public class ConfirmBookingCommandValidator : AbstractValidator<ConfirmBookingCommand>
    {
        public ConfirmBookingCommandValidator()
        {
            RuleFor(c => c.BookingId).NotEmpty();
        }
    }
}
