namespace IdentityService.Api.Helpers.Swagger
{
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System.Collections.Generic;

    public class HeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null) operation.Parameters = new List<OpenApiParameter>();

            var descriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;

            if (descriptor != null && !descriptor.ControllerName.StartsWith("Auth"))
            {
                if (operation.Parameters == null)
                    operation.Parameters = new List<OpenApiParameter>();

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "UserToken",
                    In = ParameterLocation.Header,

                });
            }
            else
            {
                if (descriptor.ActionName != null && !descriptor.ActionName.StartsWith("ValidateToken"))
                {
                    if (operation.Parameters == null)
                        operation.Parameters = new List<OpenApiParameter>();

                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = "ApiKey",
                        In = ParameterLocation.Header,

                    });
                }
                
            }
        }
    }
}
