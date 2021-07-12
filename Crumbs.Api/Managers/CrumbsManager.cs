using System.Collections.Generic;
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
        
        public ICollection<Crumb> GetAllCrumbs()
        {
            return _crumbsRepository.GetAllEntities();
        }
    }
}