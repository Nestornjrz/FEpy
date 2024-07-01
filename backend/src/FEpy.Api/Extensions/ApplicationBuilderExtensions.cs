using FEpy.Infrastructure;
using Microsoft.EntityFrameworkCore;
using FEpy.Api.Middleware;

namespace FEpy.Api.Extensions;

public static class ApplicationBuilderExtensions
{

    public static async Task ApplyMigration(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var service = scope.ServiceProvider;
            var loggerFactory = service.GetRequiredService<ILoggerFactory>();

            try
            {
                var context = service.GetRequiredService<ApplicationDbContext>();
                await context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "Error en migracion");
            }
        }
    }
    /// <summary>
    /// Agrega un Middlewara que captura las excepciones que lanzan los controladores
    /// con cada peticion
    /// </summary>
    /// <param name="app"></param>
    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }

    public static IApplicationBuilder UseRequestContextLogging(this IApplicationBuilder app)
    {
        app.UseMiddleware<RequestContextMiddleware>();
        return app;
    }
}