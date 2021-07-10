using System.Threading;
using System.Threading.Tasks;
using Crumbs.Data.Interfaces;
using Crumbs.Data.Models;
using Crumbs.Data.Repositories;
using Microsoft.Extensions.Configuration;

namespace Crumbs.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CrumbsDbContext _dbContext;
        private readonly PostgresDbConnectionProvider _connectionProvider;

        private ICrumbsRepository _crumbsRepository;
        public ICrumbsRepository CrumbsRepository => _crumbsRepository ??= new CrumbsRepository<Crumb>(_connectionProvider);

        public UnitOfWork(CrumbsDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionProvider = new PostgresDbConnectionProvider(configuration);
        }
        
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}