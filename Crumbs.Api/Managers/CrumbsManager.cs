﻿using System.Linq;
using System.Threading.Tasks;
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
        
        public IQueryable<Crumb> GetAllCrumbs()
        {
            return _crumbsRepository.GetAllCrumbs();
        }

        public Task<int> InsertCrumb(Crumb crumb)
        {
            return _crumbsRepository.InsertCrumb(crumb);
        }
    }
}