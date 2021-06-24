using System.Collections.Generic;
using Crumbs.Data.Models;

namespace Crumbs.Data.Repositories
{
    public class CrumbsRepository<T> : Repository<T>, ICrumbsRepository
    {
        public ICollection<Crumb> GetAllCrumbs()
        {
            return GetEntities<Crumb>("SELECT * FROM public.\"Crumbs\"");
        }
    }
}