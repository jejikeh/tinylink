namespace TinyUrl.Identity.Core.Application.Common.Types;

public interface IResultRequest<TSuccess, TError> 
    where TSuccess : class 
    where TError : class
{
    
}