using TinyUrl.Identity.Core.Domain.Types;

namespace TinyUrl.Identity.Core.Application.Common.Models.Services;

public class NotificationError(string message, int statusCode) : Error(message, statusCode)
{
}