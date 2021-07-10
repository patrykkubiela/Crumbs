using System.Collections.Generic;
using Crumbs.Data.Interfaces;
using Crumbs.Data.Models;

namespace Crumbs.Data.Repositories
{
    public class CrumbsRepository<T> : Repository<T>, ICrumbsRepository
    {
        private readonly PostgresDbConnectionProvider _connectionProvider;

        public CrumbsRepository(PostgresDbConnectionProvider connectionProvider)
            : base(connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }
        
        public ICollection<Crumb> GetAllEntities()
        {
            return GetEntities<Crumb>("SELECT * FROM public.\"Crumbs\"");
        }
    }
}