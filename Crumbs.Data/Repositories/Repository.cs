using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Crumbs.Data.Repositories
{
    public class Repository<T> where T: class
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

        public long InsertEntity<T>(T entity) where T: class
        {
            using var connection = _connectionProvider.GetDbConnection();
            return connection.Insert(entity);
        }
    }
}