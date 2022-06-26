namespace IdentityService.Services.Auth
{
    using DataTransferObject.Security;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using System.Threading;
    using System.Threading.Tasks;
    using Utilities.Service;

    public class AuthSignInHandler : BaseServices<AuthSignInHandler>, IRequestHandler<LoginDto, Response>
    {

        public AuthSignInHandler(ILogger<AuthSignInHandler> logger) : base(logger)
        {

        }

        public async Task<Response> Handle(LoginDto request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
