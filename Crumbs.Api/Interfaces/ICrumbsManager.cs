using System.Linq;
using System.Threading.Tasks;
using Crumbs.Data.Models;

namespace Crumbs.Api.Interfaces
{
    public interface ICrumbsManager
    {
        IQueryable<Crumb> GetAllCrumbs();
        Task<int> InsertCrumb(Crumb crumb);
    }
}