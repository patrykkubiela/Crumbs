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

        public IQueryable<CrumbDto> GetAllCrumbs()
        {
            var crumbsModels = _crumbsRepository.GetAllCrumbs();
            
            var result = crumbsModels.Select(c =>
                new CrumbDto(c.Uuid, c.Observers.ConvertToDtos())
                {
                    Name = c.Name,
                    Description = c.Description,
                    Type = c.Type
                });

            return result;
        }

        public Task<int> InsertCrumb(Crumb crumb)
        {
            return _crumbsRepository.InsertCrumb(crumb);
        }
    }
}