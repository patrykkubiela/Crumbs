using System.Threading;
using System.Threading.Tasks;

namespace Crumbs.Data.Interfaces
{
    public interface IUnitOfWork
    {
        ICrumbsRepository CrumbsRepository { get; }
        IUserRepository UserRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}