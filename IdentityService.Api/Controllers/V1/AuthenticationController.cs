namespace IdentityService.Api.Controllers.V1
{
    using DataTransferObject.Security;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    [ApiVersion("1.0")]
    public class AuthenticationController : BaseController<AuthenticationController>
    {

        public AuthenticationController(ILogger<AuthenticationController> logger) : base(logger)
        {

        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromServices] IMediator mediator, [FromBody] LoginDto dto)
        {
            logger.LogInformation("SignIn");
            var result = await mediator.Send(dto);
            return Ok(dto);
        }

    }
}
