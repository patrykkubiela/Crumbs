using System.Collections.Generic;
using Crumbs.Api.Requests;
using Crumbs.Api.Responses;
using Crumbs.Data.Models;

namespace Crumbs.Api.Interfaces
{
    public interface IUserManager
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(long id);
        void Register(RegisterRequest model);
        void Update(long id, UpdateRequest model);
        void Delete(long id);
    }
}