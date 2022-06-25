namespace Infrastructure.MediatR
{
    using global::MediatR;
    using Infrastructure.Logging;
    using Infrastructure.Validator;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static class MediatRExtensions
    {
        public static IServiceCollection AddCustomMediatR<TType>(this IServiceCollection services, Action<IServiceCollection> doMoreActions = null)
        {
            services.AddMediatR(typeof(TType))
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>))
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            doMoreActions?.Invoke(services);

            return services;
        }
    }
}
