namespace IdentityService.Services
{
    using DataTransferObject.Security;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;
    using Utilities.Service;

    public class AuthService : BaseServices<AuthService>, IAuthService
    {
        public AuthService(ILogger<AuthService> logger) : base(logger)
        {

        }

        public Task<Response> SingInAsync(LoginDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
