using Bookify.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
{
}
public interface IBaseCommand
{

}