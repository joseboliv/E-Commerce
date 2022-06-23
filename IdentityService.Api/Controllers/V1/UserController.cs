using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityService.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    public class UserController : BaseController<UserController>
    {
        public UserController()
        {

        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Register()
        {


            return Ok();
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword()
        {


            return Ok();
        }

        [HttpPost("ChangedPassword")]
        public async Task<IActionResult> ChangedPassword()
        {


            return Ok();
        }
    }
}
