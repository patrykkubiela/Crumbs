using Crumbs.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Crumbs.Api.Controllers
{
    [ApiController]
    [Route("crumb")]
    public class CrumbController: ControllerBase
    {
        private readonly ICrumbsRepository _crumbsRepository;

        public CrumbController(ICrumbsRepository crumbsRepository)
        {
            _crumbsRepository = crumbsRepository;
        }
        
        [HttpGet]
        public IActionResult GetTest()
        {
            var crumbs = _crumbsRepository.GetCrumbs("SELECT * FROM public.\"Queries\"");
            return Ok("Testing crumb controller");
        }
    }
}