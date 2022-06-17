namespace IdentityService.Api.Middleware
{
    using Microsoft.AspNetCore.Http;
    using System.Linq;
    using System.Threading.Tasks;

    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context/*, IAuthUseCases userService, IJwtFactory jwtUtils*/)
        {
            var authorizationToken = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (authorizationToken != null)
            {
                //bool validateAclCredential = await userService.ValidateToken(authorizationToken);
                //context.Items["ValidToken"] = validateAclCredential;
            }

            var token = context.Request.Headers["UserToken"].FirstOrDefault()?.Split(" ").Last();
            //var user = jwtUtils.ValidateJwtToken(token);
            //if (user != null)
            //{
            //    //Validar Id y role
            //    // attach user to context on successful jwt validation
            //    context.Items["User"] = user;
            //}

            await _next(context);
        }
    }
}
