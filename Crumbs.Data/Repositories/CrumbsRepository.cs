using System.Linq;
using System.Threading.Tasks;
using Crumbs.Data.Interfaces;
using Crumbs.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Crumbs.Data.Repositories
{
    public class CrumbsRepository : ICrumbsRepository
    {
        private readonly CrumbsDbContext _crumbsDbContext;

        public CrumbsRepository(CrumbsDbContext crumbsDbContext)
        {
            _crumbsDbContext = crumbsDbContext;
        }

        public IQueryable<Crumb> GetAllCrumbs()
        {
            var allCrumbs = _crumbsDbContext.Crumbs.AsNoTracking();
            return allCrumbs;
        }

        public Task<int> InsertCrumb(Crumb crumb)
        {
            _crumbsDbContext.Crumbs.AddAsync(crumb);
            var result = _crumbsDbContext.SaveChangesAsync();
            return result;
        }
    }
}