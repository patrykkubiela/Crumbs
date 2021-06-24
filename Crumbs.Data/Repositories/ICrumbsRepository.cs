using System.Collections.Generic;
using Crumbs.Data.Models;

namespace Crumbs.Data.Repositories
{
    public interface ICrumbsRepository
    {
        ICollection<Crumb> GetAllCrumbs();
    }
}