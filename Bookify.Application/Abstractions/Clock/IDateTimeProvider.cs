using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Application.Abstractions.Clock
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
