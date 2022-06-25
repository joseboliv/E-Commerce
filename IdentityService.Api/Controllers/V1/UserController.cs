namespace IdentityService.Api.Controllers.V1
{
    using IdentityService.Api.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    [ApiVersion("1.0")]
    public class UserController : BaseController<UserController>
    {
        public UserController(ILogger<UserController> logger) : base(logger)
        {

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            throw new ArgumentNullException("Aqui sali oerror");
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
