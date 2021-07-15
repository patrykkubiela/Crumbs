using Crumbs.Api.Interfaces;
using Crumbs.Data.Models;
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

        [HttpPost]
        [Route("add")]
        public IActionResult AddCrumb([FromBody] Crumb crumb)
        {
            var result = _crumbsManager.InsertCrumb(crumb);
            return Ok(result);
        }
    }
}