using Movies.Api.Health;

namespace Movies.Api.Extensions;

public static class HealthCheckExtensions
{
    public static IServiceCollection AddMoviesHealthCheck(this IServiceCollection services)
    {
        services
            .AddHealthChecks()
            .AddCheck<DatabaseHealthCheck>(DatabaseHealthCheck.Name);

        return services;
    }
}
