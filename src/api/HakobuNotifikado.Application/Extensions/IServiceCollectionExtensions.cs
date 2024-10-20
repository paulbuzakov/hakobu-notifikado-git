using Microsoft.Extensions.DependencyInjection;

namespace HakobuNotifikado.Application.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationLib(this IServiceCollection services)
    {
        return services;
    }
}
