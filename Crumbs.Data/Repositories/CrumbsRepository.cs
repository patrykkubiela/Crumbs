using System.Collections.Generic;
using Crumbs.Data.Interfaces;
using Crumbs.Data.Models;

namespace Crumbs.Data.Repositories
{
    public class CrumbsRepository<T> : Repository<T>, ICrumbsRepository
    {
        public ICollection<Crumb> GetAllEntities()
        {
            return GetEntities<Crumb>("SELECT * FROM public.\"Crumbs\"");
        }
    }
}