namespace IdentityService.Module
{
    using DataTransferObject.Security;
    using FluentValidation;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IValidator<LoginDto>, LoginValidator>();
            return services;
        }
    }
}
