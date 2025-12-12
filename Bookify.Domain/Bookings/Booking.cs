using Bookify.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Domain.Bookings;

public class Booking : Entity
{
    public Booking(Guid id) : base(id)
    {

    }

    public Guid ApartmentId { get; private set; }
    public Guid UserId { get; private set; }


}
