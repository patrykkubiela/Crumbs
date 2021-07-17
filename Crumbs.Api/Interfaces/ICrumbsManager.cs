using System.Collections.Generic;
using System.Threading.Tasks;
using Crumbs.Api.BusinessModels;
using Crumbs.Data.Models;

namespace Crumbs.Api.Interfaces
{
    public interface ICrumbsManager
    {
        IEnumerable<CrumbDto> GetAllCrumbs();
        Task<int> InsertCrumb(Crumb crumb);
    }
}