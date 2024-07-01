using FEpy.Api.Dependencies;

namespace FEpy.Api
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Organiza todas las demas dependencias de la aplicacion, este metodo de extension organiza todas las dependencias 
        /// generadas dentro de esta capa de la aplicacion, que no tienen que ver directamente con las otras capas
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddOtherServicesToContainer(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAppDbContext(configuration)
                .AddGmailSettings(configuration)
                .AddSwaggerStuff();
            return services;
        }
    }
}
