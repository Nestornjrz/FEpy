using FEpy.Infrastructure.Email;

namespace FEpy.Api.Dependencies
{
    internal static class AddGmailSettingstExtension
    {

        public static IServiceCollection AddGmailSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GmailSettings>(configuration.GetSection("GmailSettings"));
            return services;
        }
    }
}