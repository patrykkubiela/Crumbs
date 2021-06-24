using Crumbs.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Crumbs.Api.Controllers
{
    [ApiController]
    [Route("crumb")]
    public class CrumbController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CrumbController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetTest()
        {
            var crumbs = _unitOfWork.CrumbsRepository.GetAllCrumbs();
            return Ok(crumbs);
        }
    }
}