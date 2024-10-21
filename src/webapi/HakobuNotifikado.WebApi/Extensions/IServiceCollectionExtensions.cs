using HakobuNotifikado.WebApi.Middleware;

namespace HakobuNotifikado.WebApi.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddWebApiLib(this IServiceCollection services)
    {
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = XApiTokenAuthenticationOptions.DefaultScheme;
                options.DefaultChallengeScheme = XApiTokenAuthenticationOptions.DefaultScheme;
            })
            .AddScheme<XApiTokenAuthenticationOptions, XApiTokenAuthenticationHandler>(
                XApiTokenAuthenticationOptions.DefaultScheme,
                null
            );

        services.AddEndpointsApiExplorer().AddSwaggerGen();
        services.AddAuthorization();
        services.AddControllers();

        return services;
    }
}
