using Microsoft.AspNetCore.Mvc;

namespace Crumbs.Api.Controllers
{
    [ApiController]
    [Route("crumb")]
    public class CrumbController: ControllerBase
    {
        [HttpGet]
        public IActionResult GetTest()
        {
            return Ok("Testing crumb controller");
        }
    }
}