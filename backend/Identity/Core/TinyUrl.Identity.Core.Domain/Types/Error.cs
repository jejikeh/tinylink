namespace TinyUrl.Identity.Core.Domain.Types;

public class Error(string message, int statusCode)
{
    public string Message { get; set; } = message;
    public int StatusCode { get; set; } = statusCode;
}