using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crumbs.Api.BusinessModels;
using Crumbs.Api.Interfaces;
using Crumbs.Data.Interfaces;
using Crumbs.Data.Models;

namespace Crumbs.Api.Managers
{
    public class CrumbsManager : ICrumbsManager
    {
        private readonly ICrumbsRepository _crumbsRepository;

        public CrumbsManager(IUnitOfWork unitOfWork)
        {
            _crumbsRepository = unitOfWork.CrumbsRepository;
        }

        public IEnumerable<CrumbDto> GetAllCrumbs()
        {
            var crumbsModels = _crumbsRepository
                .GetAllCrumbs()
                .Where(c => c.BroadcasterId == null)
                .ToList();

            var result = crumbsModels.ConvertToDtos();
            
            return result;
        }

        public Task<int> InsertCrumb(Crumb crumb)
        {
            return _crumbsRepository.InsertCrumb(crumb);
        }
    }
}