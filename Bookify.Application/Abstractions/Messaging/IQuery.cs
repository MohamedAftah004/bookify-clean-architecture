using Bookify.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
