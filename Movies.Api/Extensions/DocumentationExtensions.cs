using Movies.Api.Scalar.Transformers;
using Scalar.AspNetCore;

namespace Movies.Api.Extensions;

public static class DocumentationExtensions
{
    public static IServiceCollection AddMoviesDocumentation(this IServiceCollection services)
    {
        services.AddOpenApi("v1", options =>
        {
            options.AddDocumentTransformer<BearerSecurityDocumentTransformer>();
        });
        return services;
    }

    public static WebApplication UseMoviesDocumentation(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference(options =>
            {
                options
                    .WithTitle("Movies Demo")
                    .WithTheme(ScalarTheme.Mars)
                    .WithDefaultHttpClient(ScalarTarget.Shell, ScalarClient.HttpClient);
                options.Authentication = new ScalarAuthenticationOptions
                {
                    PreferredSecuritySchemes = ["Bearer"]
                };
                options.AddDocuments(["v1"]);
            });
        }
        return app;
    }
}
