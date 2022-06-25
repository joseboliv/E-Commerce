namespace IdentityService.Services
{
    using DataTransferObject.Security;
    using System.Threading.Tasks;

    public interface IAuthService
    {
        Task<Response> SingInAsync(LoginDto dto);
    }
}
