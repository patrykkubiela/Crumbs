using System.Collections.Generic;

namespace Crumbs.Data.Interfaces
{
    public interface IRepository<T>
    {
        ICollection<T> GetAllEntities();
        long InsertCrumb(T entity);
    }
}