using Bookify.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Application.Features.Bookings.Queries.GetUserBookings;

public sealed record GetUserBookingsQuery(Guid UserId) : IQuery<IReadOnlyList<BookingSummaryResponse>>;
