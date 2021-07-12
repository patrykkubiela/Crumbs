using Crumbs.Api.Managers;
using Microsoft.AspNetCore.Mvc;

namespace Crumbs.Api.Controllers
{
    [ApiController]
    [Route("crumb")]
    public class CrumbController : ControllerBase
    {
        private readonly ICrumbsManager _crumbsManager;

        public CrumbController(ICrumbsManager crumbsManager)
        {
            _crumbsManager = crumbsManager;
        }

        [HttpGet]
        public IActionResult GetTest()
        {
            var crumbs = _crumbsManager.GetAllCrumbs();
            return Ok(crumbs);
        }
    }
}