namespace IdentityService.Api.Authorization
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        //private readonly IList<AccessLevel> _roles;

        //public AuthorizeAttribute(params AccessLevel[] roles)
        //{
        //    _roles = roles ?? new AccessLevel[] { };
        //}

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool validToken = false;
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (context.HttpContext.Items["ValidToken"] != null)
                validToken = (bool)context.HttpContext.Items["ValidToken"];

            if (allowAnonymous || validToken)
                return;

            // authorization
            //var user = (AuthorizationModel)context.HttpContext.Items["User"];
            //if (user == null || (_roles.Any() && !_roles.Contains(user.AccessLevel)))
            //{
            //    // not logged in or role not authorized
            //    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            //}
        }
    }
}
