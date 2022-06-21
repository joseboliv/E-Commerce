namespace Authentication.ContextAccesor
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Linq;
    using System.Security.Claims;

    public class SecurityContextAccessor : ISecurityContextAccessor
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public SecurityContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(IHttpContextAccessor));
        }

        public Guid UserId
        {
            get
            {
                var userId = Guid.Parse(httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                return userId;
            }
        }

        public string JwtToken
        {
            get
            {
                return httpContextAccessor.HttpContext?.Request?.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                var isAuthenticated = httpContextAccessor.HttpContext?.User?.Identities?.FirstOrDefault()?.IsAuthenticated;
                if (!isAuthenticated.HasValue)
                {
                    return false;
                }

                return isAuthenticated.Value;
            }
        }

        public string Email
        {
            get
            {
                var Email = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;
                return Email;
            }
        }
    }
}
