using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using YoutubePractise.HealthChecksExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks()
                .AddSqlServer(builder.Configuration.GetConnectionString("sqlConnection")!, name: "SqlHealth", tags: new List<string>() {"database"})
                .AddCheck<CustomHealthCheck>("CustomHealthCheck", tags: new List<string>() { "custom" });
builder.Services.AddHealthChecksUI()
    .AddInMemoryStorage();

var app = builder.Build();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapHealthChecks("/health/custom", new HealthCheckOptions
{
    Predicate = reg => reg.Tags.Contains("custom"),
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapHealthChecksUI();

app.Run();
