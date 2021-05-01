using System.Collections.Generic;
using System.Linq;
using Crumbs.Data.Models;
using Dapper;

namespace Crumbs.Data.Repositories
{
    public class CrumbsRepository : ICrumbsRepository
    {
        public ICollection<Crumb> GetCrumbs(string query)
        {
            using var connection = PostgresDbConnectionProvider.GetDbConnection();
            var events = connection.Query<Crumb>(query).ToList();
            return events;
        }
    }
}