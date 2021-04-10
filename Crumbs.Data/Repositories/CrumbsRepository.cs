using System.Collections.Generic;
using System.Linq;
using Crumbs.Data.Models;
using Dapper;

namespace Crumbs.Data.Repositories
{
    public class CrumbsRepository : ICrumbsRepository
    {
        private readonly PostgresDbConnectionProvider _connectionProvider;

        public CrumbsRepository(PostgresDbConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public ICollection<Crumb> GetCrumbs(string query)
        {
            using (var connection = _connectionProvider.GetDbConnection())
            {
                var events = connection.Query<Crumb>(query).ToList();
                return events;
            }
        }
    }
}