using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace Crumbs.Data.Repositories
{
    public class Repository<T>
    {
        private PostgresDbConnectionProvider _connectionProvider;

        public Repository(PostgresDbConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public ICollection<T> GetEntities<T>(string query)
        {
            using var connection = _connectionProvider.GetDbConnection();
            var events = connection.Query<T>(query).ToList();
            return events;
        }
    }
}