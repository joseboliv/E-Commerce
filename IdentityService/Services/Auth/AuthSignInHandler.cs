namespace IdentityService.Services.Auth
{
    using DataTransferObject.Security;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class AuthSignInHandler : IRequestHandler<LoginDto, Response>
    {
        public AuthSignInHandler()
        {

        }

        public async Task<Response> Handle(LoginDto request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
