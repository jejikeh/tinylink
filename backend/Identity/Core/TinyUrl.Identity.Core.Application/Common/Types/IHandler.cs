using TinyUrl.Identity.Core.Domain.Types;

namespace TinyUrl.Identity.Core.Application.Common.Types;

public interface IHandler<in TRequest, TSuccess, TError> 
    where TRequest : IResultRequest<TSuccess, TError>
    where TSuccess : Success
    where TError : Error
{
    public Task<Result<TSuccess, TError>> Handle(TRequest request, CancellationToken cancellationToken);
}