using TinyUrl.Identity.Core.Application.Common.Models.Configuration;

namespace TinyUrl.Identity.Core.Application.Common;

public interface IIdentityApplicationConfiguration
{
    RegistrationConfiguration Registration { get; }
}