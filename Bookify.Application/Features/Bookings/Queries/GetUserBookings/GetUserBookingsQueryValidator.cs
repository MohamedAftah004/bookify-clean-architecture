using FluentValidation;

namespace Bookify.Application.Features.Bookings.Queries.GetUserBookings;

internal sealed class GetUserBookingsQueryValidator
    : AbstractValidator<GetUserBookingsQuery>
{
    public GetUserBookingsQueryValidator()
    {
        RuleFor(q => q.UserId)
            .NotEmpty();
    }
}
