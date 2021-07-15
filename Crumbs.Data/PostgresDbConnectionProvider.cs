using System;
using Npgsql;

namespace Crumbs.Data
{
    public class PostgresDbConnectionProvider
    {
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
                Database = databaseUri.LocalPath.TrimStart('/')
            };

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Testing")
                builder.SslMode = SslMode.Require;

            var bobTheBuilder = builder.ToString();
            return bobTheBuilder;
        }
    }
}