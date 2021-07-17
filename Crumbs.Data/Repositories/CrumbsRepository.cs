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
            var allCrumbs = _crumbsDbContext
                .Crumbs
                .Include(c => c.Observers)
                .AsNoTracking();
            return allCrumbs;
        }

        public async Task<int> InsertCrumb(Crumb crumb)
        {
            await _crumbsDbContext.Crumbs.AddAsync(crumb);
            var result = await _crumbsDbContext.SaveChangesAsync();
            return result;
        }
    }
}