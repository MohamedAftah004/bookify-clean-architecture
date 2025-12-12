using Bookify.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Domain.Bookings.Events;

public sealed record BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;
