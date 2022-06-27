namespace IdentityService.Api
{
    using Authentication.Module;
    using IdentityService.Api.Helpers;
    using IdentityService.Api.Helpers.Swagger;
    using IdentityService.Api.Middleware;
    using IdentityService.Api.Modules.FeatureFlags;
    using IdentityService.Context;
    using IdentityService.Module;
    using Infrastructure.EfCore;
    using Infrastructure.MediatR;
    using Infrastructure.Validator;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddVersioning();
            services.AddFeatureFlags(Configuration);
            services.AddSwagger();
            services.AddCustomValidators<Anchor>();
            services.AddCustomMediatR<Anchor>();
            services.AddAuthentication(Configuration);
            services.AddServices();
            services.AddValidatorIdentity();
            services.AddCustomDbContext<IdentityDbContext, Anchor>(Configuration);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseVersionedSwagger(provider, Configuration, env);
            app.UseMiddleware<JwtMiddleware>();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            //app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
