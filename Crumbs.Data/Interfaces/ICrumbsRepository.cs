using System.Linq;
using System.Threading.Tasks;
using Crumbs.Data.Models;

namespace Crumbs.Data.Interfaces
{
    public interface ICrumbsRepository
    {
        IQueryable<Crumb> GetAllCrumbs();
        Task<int> InsertCrumb(Crumb crumb);
    }
}