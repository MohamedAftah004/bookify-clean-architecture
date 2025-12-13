using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Application.Exceptions;

public class ConcurrencyException : Exception
{
    public ConcurrencyException(string message , Exception innerException) : base(message ,innerException)
    {
    }
}
