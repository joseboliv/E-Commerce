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
            //TODO: Login de usuario

            //Agregar validaciones

            //Cantidad de reintentos

            //Estatus del usuario y role (IsActive o IsDelete)

            //Validar password

            //Fecha de caducidad del usuario

            //Debe estar validado via email o sms (Construir servicios)

            throw new System.NotImplementedException();
        }
    }
}
