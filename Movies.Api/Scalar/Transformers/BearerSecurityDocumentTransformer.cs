using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

namespace Movies.Api.Scalar.Transformers;

public sealed class BearerSecurityDocumentTransformer : IOpenApiDocumentTransformer
{
    public Task TransformAsync(
        OpenApiDocument document, 
        OpenApiDocumentTransformerContext context, 
        CancellationToken cancellationToken)
    {
        document.Components ??= new OpenApiComponents();
        document.Components.SecuritySchemes ??= new Dictionary<string, OpenApiSecurityScheme>();

        document.Components.SecuritySchemes["Bearer"] = new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Description = "Use format: Bearer {your JWT}"
        };

        document.SecurityRequirements ??=
            [
                new OpenApiSecurityRequirement
                {
                    [ new OpenApiSecurityScheme
                       { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }
                    ] = Array.Empty<string>()
                }
            ];

        return Task.CompletedTask;
    }
}
