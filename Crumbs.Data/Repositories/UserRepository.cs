using System.Collections.Generic;
using System.Threading.Tasks;
using Crumbs.Data.Interfaces;
using Crumbs.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Crumbs.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CrumbsDbContext _crumbsDbContext;

        public UserRepository(CrumbsDbContext crumbsDbContext)
        {
            _crumbsDbContext = crumbsDbContext;
        }

        public async Task<User> GetUser(string username)
        {
            var user = await _crumbsDbContext.Users.SingleAsync(u => u.Username == username);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public async Task<User> GetUser(long id)
        {
            var user = await _crumbsDbContext.Users.SingleAsync(u => u.Id == id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _crumbsDbContext.Users.ToListAsync();
        }

        public async Task<int> AddUser(User user)
        {
            await _crumbsDbContext.Users.AddAsync(user);
            return await _crumbsDbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateUser(User user)
        {
            _crumbsDbContext.Users.Update(user);
            return await _crumbsDbContext.SaveChangesAsync();
        }

        public async Task<int> RemoveUser(User user)
        {
            _crumbsDbContext.Remove(user);
            return await _crumbsDbContext.SaveChangesAsync();
        }
    }
}