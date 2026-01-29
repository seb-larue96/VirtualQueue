using Microsoft.Extensions.DependencyInjection;

namespace VirtualQueue.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
