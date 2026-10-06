using Movies.Api.Extensions;
using Movies.Api.Mapping;
using Movies.Application;
using Movies.Application.Database;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;

builder.Services.AddMoviesAuthentication(config);
builder.Services.AddMoviesAuthorization();

builder.Services.AddMoviesVersioning();

builder.Services.AddControllers();

builder.Services.AddMoviesHealthCheck();

builder.Services.AddMoviesDocumentation();

builder.Services.AddApplication();

builder.Services.AddDatabase(config["Database:ConnectionString"]!);

WebApplication app = builder.Build();

app.UseMoviesDocumentation();

app.MapHealthChecks("_health");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ValidationMappingMiddleware>();
app.MapControllers();

DbInitializer dbInitializer = app.Services.GetRequiredService<DbInitializer>();
await dbInitializer.InitializeAsync();

app.Run();
