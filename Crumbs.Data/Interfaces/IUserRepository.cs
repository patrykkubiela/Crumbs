using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crumbs.Data.Models;

namespace Crumbs.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(string username);
        Task<User> GetUser(long id);
        Task<List<User>> GetUsers();
        Task<int> AddUser(User user);
        Task<int> UpdateUser(User user);
        Task<int> RemoveUser(User user);
    }
}