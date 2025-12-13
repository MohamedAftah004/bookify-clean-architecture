using Bookify.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Application.Features.Bookings.Queries.GetBooking;

public sealed record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;