using Microsoft.Extensions.DependencyInjection;
using TinyUrl.Identity.Core.Application.Common.Types;

namespace TinyUrl.Identity.Core.Application;

public static class IdentityApplicationInjection
{
    public static IServiceCollection AddIdentityApplication(this IServiceCollection services)
    {
        return services
            .AddRequestHandlers();
    }

    private static IServiceCollection AddRequestHandlers(this IServiceCollection services)
    {
        var handlersTypes = typeof(IHandler<,,>).Assembly
            .GetTypes()
            .Where(x => x is { IsClass: true, IsAbstract: false, IsInterface: false } && x.IsAssignableTo(typeof(IHandler<,,>)));
        
        foreach (var type in handlersTypes)
        {
            services.AddTransient(type);
        }
        
        return services;
    } 
}