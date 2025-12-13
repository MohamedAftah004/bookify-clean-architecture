using Bookify.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Application.Features.Apartments.Queries.SearchApartments;

public sealed record SearchApartmentsQuery(
    DateOnly StartDate,
    DateOnly EndDate ) : IQuery<IReadOnlyList<ApartmentResponse>>;

