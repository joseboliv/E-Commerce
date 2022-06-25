namespace IdentityService.Api.Middleware
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Hosting;
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Threading.Tasks;

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate next, IHostEnvironment env)
        {
            this.next = next;
            this.env = env;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, env);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception, IHostEnvironment env) => WriteResponse(httpContext, exception, env.IsDevelopment());

        private static Task WriteResponse(HttpContext httpContext, Exception exception, bool includeDetails)
        {
            httpContext.Response.ContentType = "application/problem+json";
            httpContext.Response.StatusCode = httpContext.Response.StatusCode.Equals(200) ? (int)HttpStatusCode.InternalServerError : httpContext.Response.StatusCode;
            ProblemDetails problem = new()
            {
                Title = includeDetails ? "An error occured: " + exception.Message : "An error occured",
                Type = exception.GetType().Name,
                Status = httpContext.Response.StatusCode,
                Detail = includeDetails ? exception.ToString() : string.Empty
            };

            if (includeDetails) problem.Extensions["traceId"] = Activity.Current?.Id ?? httpContext?.TraceIdentifier ?? string.Empty;

            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(problem));
        }
    }
}
