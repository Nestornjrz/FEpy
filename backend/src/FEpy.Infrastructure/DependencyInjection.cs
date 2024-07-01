using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using FEpy.Application.Abstractions.Clock;
using FEpy.Application.Abstractions.Data;
using FEpy.Application.Abstractions.Email;
using FEpy.Domain.Abstractions;
using FEpy.Domain.Entities.Personas;
using FEpy.Infrastructure.Clock;
using FEpy.Infrastructure.Data;
using FEpy.Infrastructure.Outbox;
using FEpy.Infrastructure.Repositories.Entities;

namespace FEpy.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Es la inyección de dependencias de la capa de infraestructura
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IServiceCollection AddInfrastructureLayerDependencies(this IServiceCollection services, IConfiguration configuration)
    {

        #region OUTBOX, QUARTZ
        services.Configure<OutboxOptions>(configuration.GetSection("Outbox"));
        services.AddQuartz();
        services.AddQuartzHostedService(options =>
        {
            options.WaitForJobsToComplete = true;
        });
        services.ConfigureOptions<ProcessOutboxMessageSetup>();
        #endregion
        #region Versioning para los controladores
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1);
            options.ReportApiVersions = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        }).AddMvc()
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        });
        #endregion
        #region Servicios basicos
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IEmailService, EmailService>();
        services.AddHttpContextAccessor();
        #endregion
        #region DbContext
        var connectionString = configuration.GetConnectionString("SqlServerConnection")
              ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        #endregion
        #region ConnectionFactory
        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlServerConnectionFactory(connectionString));
        #endregion
        #region Repositories
        services.AddScoped<IPersonaRepository, PersonaRepository>();
        #endregion
        #region UnitOfWork
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
        #endregion
        return services;
    }
}
