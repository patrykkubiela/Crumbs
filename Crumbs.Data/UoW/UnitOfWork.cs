using System.Threading;
using System.Threading.Tasks;
using Crumbs.Data.Interfaces;
using Crumbs.Data.Repositories;

namespace Crumbs.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CrumbsDbContext _dbContext;

        private ICrumbsRepository _crumbsRepository;
        private IUserRepository _userRepository;
        
        public ICrumbsRepository CrumbsRepository => _crumbsRepository ??= new CrumbsRepository(_dbContext);
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_dbContext);

        public UnitOfWork(CrumbsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}