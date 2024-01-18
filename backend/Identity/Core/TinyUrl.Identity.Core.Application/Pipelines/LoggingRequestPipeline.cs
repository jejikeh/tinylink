namespace TinyUrl.Identity.Core.Application.Pipelines;

public class LoggingRequestPipeline
{
    public async  Task<TResponse> Handle<TRequest, TResponse>(
        TRequest request,
        Func<TRequest, CancellationToken, Task<TResponse>> handler, 
        CancellationToken cancellationToken = default)
    {
        var result = await handler(request, cancellationToken);
        return result;
    }
}