using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Application.Exceptions;

public sealed record ValidationError(string PropertyName, string ErrorMessage);
