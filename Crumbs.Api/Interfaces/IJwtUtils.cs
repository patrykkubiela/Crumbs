using Crumbs.Data.Models;

namespace Crumbs.Api.Interfaces
{
    public interface IJwtUtils
    {
        public string GenerateToken(User user);
        public int? ValidateToken(string token);
    }
}