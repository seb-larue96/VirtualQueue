using Microsoft.Extensions.DependencyInjection;
using VirtualQueue.Application.Interfaces;
using VirtualQueue.Infrastructure.Persistence.InMemory;

namespace VirtualQueue.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IQueueService, InMemoryQueueService>();

        return services;
    }
}
