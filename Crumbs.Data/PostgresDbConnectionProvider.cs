using System;
using Npgsql;

namespace Crumbs.Data
{
    public static class PostgresDbConnectionProvider
    {
        public static NpgsqlConnection GetDbConnection()
        {
            return new NpgsqlConnection(GetDbConnectionString());
        }

        public static string GetDbConnectionString()
        {
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');

            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Require
            };

            var bobTheBuilder = builder.ToString();
            return bobTheBuilder;
        }
    }
}