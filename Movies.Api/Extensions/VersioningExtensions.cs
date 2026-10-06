using Asp.Versioning;

namespace Movies.Api.Extensions;

public static class VersioningExtensions
{
    public static IApiVersioningBuilder AddMoviesVersioning(this IServiceCollection services)
    {
        return services.AddApiVersioning(x =>
        {
            x.DefaultApiVersion = new ApiVersion(1.0);
            x.AssumeDefaultVersionWhenUnspecified = true;
            x.ReportApiVersions = true;
            x.ApiVersionReader = new MediaTypeApiVersionReader("api-version");
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.AssumeDefaultVersionWhenUnspecified = true;
        }).AddMvc();
    }
}
