using System;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Crumbs.Data
{
    public class PostgresDbConnectionProvider
    {
        private readonly ServiceConfiguration _serviceConfiguration;
        
        public PostgresDbConnectionProvider(IConfiguration configuration)
        {
            _serviceConfiguration = configuration.GetSection(nameof(ServiceConfiguration))
                .Get<ServiceConfiguration>();
        }
        
        public NpgsqlConnection GetDbConnection()
        {
            return new NpgsqlConnection(_serviceConfiguration.Database.ConnectionString);
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