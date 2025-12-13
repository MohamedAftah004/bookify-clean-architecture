using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Application.Features.Bookings.Commands.CompleteBooking
{
    public class CompleteBookingCommandValidator : AbstractValidator<CompleteBookingCommand>
    {
        public CompleteBookingCommandValidator()
        {
            RuleFor(c=>c.BookingId).NotEmpty();
        }
    }
}
