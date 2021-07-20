using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        private readonly IUnitOfWork _unitOfWork;

        public CrumbsManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public async Task<int> InsertCrumb(Crumb crumb, CancellationToken cancellationToken)
        {
            await _crumbsRepository.InsertCrumb(crumb);
            return await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}