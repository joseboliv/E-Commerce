namespace Authentication.Module
{
    using Authentication.ContextAccessor;
    using Authentication.Jwt;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;

    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Auth:SecretKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddTransient<ICredential, Credential>();
            services.AddTransient<IJwtFactory, JwtFactory>();
            services.AddTransient<ISecurityContextAccessor, SecurityContextAccessor>();
            return services;
        }
    }
}
