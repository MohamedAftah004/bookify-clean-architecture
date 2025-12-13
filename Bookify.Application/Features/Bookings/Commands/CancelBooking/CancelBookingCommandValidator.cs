using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Application.Features.Bookings.Commands.CancelBooking
{
    public class CancelBookingCommandValidator : AbstractValidator<CancelBookingCommand>
    {
        public CancelBookingCommandValidator()
        {
            RuleFor(c=>c.BookingId).NotEmpty();
        }
    }
}
