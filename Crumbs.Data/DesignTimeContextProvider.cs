using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Crumbs.Data
{
    public class DesignTimeContextProvider : IDesignTimeDbContextFactory<CrumbsDbContext>
    {
        private readonly DbContextOptionsBuilder<CrumbsDbContext> _dbContextOptionsBuilder;

        public DesignTimeContextProvider()
        {
            var baseDirectoryName = Path.GetDirectoryName(GetType().Assembly.Location);

            if (String.IsNullOrWhiteSpace(baseDirectoryName))
            {
                throw new InvalidOperationException();
            }

            var configurationRoot = new ConfigurationBuilder()
                .SetBasePath(baseDirectoryName)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var serviceConfiguration = new ServiceConfiguration();

            configurationRoot
                .GetSection(nameof(ServiceConfiguration))
                .Bind(serviceConfiguration);
            
            _dbContextOptionsBuilder = new DbContextOptionsBuilder<CrumbsDbContext>()
                .UseNpgsql(
                    serviceConfiguration.Database.ConnectionString
                );
        }
        
        public CrumbsDbContext CreateDbContext(string[] args)
        {
            return new CrumbsDbContext(_dbContextOptionsBuilder.Options);
        }
    }
}