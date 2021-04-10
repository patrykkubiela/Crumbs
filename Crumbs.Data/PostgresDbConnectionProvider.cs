using Npgsql;

namespace Crumbs.Data
{
    public class PostgresDbConnectionProvider
    {
        public NpgsqlConnection GetDbConnection()
        {
            return new NpgsqlConnection(Settings.ConnectionString);
        }
    }
}