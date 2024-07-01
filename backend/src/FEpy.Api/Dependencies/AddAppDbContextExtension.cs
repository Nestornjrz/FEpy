using Microsoft.EntityFrameworkCore;
using FEpy.Infrastructure;

namespace FEpy.Api.Dependencies
{
    public static class AddAppDbContextExtension
    {
        /// <summary>
        /// Se agregan las dependencias de todo lo que tnega que ver con el
        /// DbContext
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServerConnection")
            ?? throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
