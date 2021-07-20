using System.Threading;
using Crumbs.Api.Interfaces;
using Crumbs.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crumbs.Api.Controllers
{
    [ApiController]
    [Route("crumb")]
    [Authorize(Policy = "User")]
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

        [HttpPost]
        [Route("add")]
        public IActionResult AddCrumb([FromBody] Crumb crumb)
        {
            //TODO: fix cancellation token during mediatr implementation
            var result = _crumbsManager.InsertCrumb(crumb, new CancellationToken(false));
            return Ok(result);
        }
    }
}