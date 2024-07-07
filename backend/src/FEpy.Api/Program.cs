using Serilog;
using FEpy.Api;
using FEpy.Api.Extensions;
using FEpy.Application;
using FEpy.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddControllers();
builder.Services.AddApplicationLayerDependencies();
builder.Services.AddInfrastructureLayerDependencies(builder.Configuration);
builder.Services.AddOtherServicesToContainer(builder.Configuration);

var app = builder.Build();

// Obtener el ILogger
var logger = app.Services.GetRequiredService<ILogger<Program>>();
// Loguear el entorno actual
logger.LogInformation("Starting application in {Environment} environment", app.Environment.EnvironmentName);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("DockerDebug"))
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        var descriptions = app.DescribeApiVersions();
        foreach (var description in descriptions)
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });
}

await app.ApplyMigration();

app.SeedData();

app.UseRequestContextLogging();
app.UseSerilogRequestLogging();
app.UseCustomExceptionHandler();

app.MapControllers();

app.Run();

public partial class Program;