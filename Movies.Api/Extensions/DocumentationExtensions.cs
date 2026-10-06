using Asp.Versioning;
using Movies.Api.Scalar.Transformers;
using Scalar.AspNetCore;

namespace Movies.Api.Extensions;

public static class DocumentationExtensions
{
    public static IApiVersioningBuilder AddMoviesDocumentation(this IApiVersioningBuilder builder)
    {
        return builder.AddOpenApi(options =>
        {
            options.Document.AddDocumentTransformer<BearerSecurityDocumentTransformer>();
        });
    }

    public static WebApplication UseMoviesDocumentation(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi().WithDocumentPerVersion();
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
