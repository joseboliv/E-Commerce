namespace IdentityService.Module
{
    using IdentityService.Services;
    using Microsoft.Extensions.DependencyInjection;

    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidatorIdentity(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
