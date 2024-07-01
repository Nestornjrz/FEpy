using FEpy.Domain.Abstractions;
using MediatR;

namespace FEpy.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}