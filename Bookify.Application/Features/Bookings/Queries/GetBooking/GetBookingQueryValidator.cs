using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Application.Features.Bookings.Queries.GetBooking
{
    public sealed class GetBookingQueryValidator : AbstractValidator<GetBookingQuery>
    {
        public GetBookingQueryValidator()
        {
            RuleFor(q => q.BookingId)
            .NotEmpty();

        }
    }
}
