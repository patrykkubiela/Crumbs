using System.Collections.Generic;
using Crumbs.Data.Models;

namespace Crumbs.Api.Interfaces
{
    public interface ICrumbsManager
    {
        ICollection<Crumb> GetAllCrumbs();
    }
}