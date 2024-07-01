using FEpy.Api.Documentation;

namespace FEpy.Api.Dependencies
{
    public static class AddSwaggerStuffExtension
    {
        public static IServiceCollection AddSwaggerStuff(this IServiceCollection services)
        {

            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.ConfigureOptions<ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options => {
                options.CustomSchemaIds(type => type.ToString());
            });

            return services;
        }
    }
}
