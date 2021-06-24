using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace Crumbs.Data.Repositories
{
    public class Repository<T>
    {
        public ICollection<T> GetEntities<T>(string query)
        {
            using var connection = PostgresDbConnectionProvider.GetDbConnection();
            var events = connection.Query<T>(query).ToList();
            return events;
        }
    }
}