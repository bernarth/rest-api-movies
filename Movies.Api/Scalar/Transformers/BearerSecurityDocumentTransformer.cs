using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace Movies.Api.Scalar.Transformers;

public sealed class BearerSecurityDocumentTransformer : IOpenApiDocumentTransformer
{
    public Task TransformAsync(
        OpenApiDocument document,
        OpenApiDocumentTransformerContext context,
        CancellationToken cancellationToken)
    {
        document.Components ??= new OpenApiComponents();
        document.Components.SecuritySchemes ??= new Dictionary<string, IOpenApiSecurityScheme>();

        document.Components.SecuritySchemes["Bearer"] = new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Description = "Use format: Bearer {your JWT}"
        };

        document.Security ??=
            [
                new OpenApiSecurityRequirement
                {
                    [ new OpenApiSecuritySchemeReference("Bearer", document) ] = []
                }
            ];

        return Task.CompletedTask;
    }
}
