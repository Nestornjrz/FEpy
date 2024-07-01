using Microsoft.Extensions.DependencyInjection;

namespace FEpy.Application;

public static class DependencyInjection
{
    /// <summary>
    /// Es la inyeccion de dependencias de la capa de aplicacion
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddApplicationLayerDependencies(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });
        return services;
    }
}
