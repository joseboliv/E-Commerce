namespace IdentityService.Services
{
    using Microsoft.Extensions.Logging;
    using Utilities.Service;

    public class UserService : BaseServices<UserService>, IUserService
    {
        public UserService(ILogger<UserService> logger) : base(logger)
        {

        }

        //TODO: Construir metodo para la validacion de permisos
        //Recibe UserId, ActionName y retorna si este tiene permisos
    }
}
