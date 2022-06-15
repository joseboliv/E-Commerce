
namespace IdentityService.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController<HomeController>
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
