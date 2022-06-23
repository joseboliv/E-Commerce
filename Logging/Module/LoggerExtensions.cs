namespace Logging
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Serilog;

    public static class LoggerExtensions
    {

        public static IServiceCollection AddSerilog(this IServiceCollection services, IConfiguration conf)
        {
            var configuration2 = new ConfigurationBuilder();
            var env = conf;
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            return services;
        }
    }
}
