
namespace IdentityService.Api.Controllers
{
    using IdentityService.Api.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    public class HomeController : BaseController<HomeController>
    {
        [AllowAnonymous]
        [HttpGet()]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
