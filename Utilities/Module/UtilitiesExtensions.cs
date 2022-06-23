namespace Utilities.Module
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Utilities.EmailSender;
    using Utilities.EmailSender.Models;

    public static class UtilitiesExtensions
    {
        public static IServiceCollection AddUtilities(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<EmailSettings>(config.GetSection(nameof(EmailSettings)));
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}
