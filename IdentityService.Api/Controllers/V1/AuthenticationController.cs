namespace IdentityService.Api.Controllers.V1
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiVersion("1.0")]
    public class AuthenticationController : BaseController<AuthenticationController>
    {
        public AuthenticationController()
        {

        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn()
        {


            return Ok();
        }
        
    }
}
