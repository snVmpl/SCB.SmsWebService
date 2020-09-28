using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCB.Data.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> Entities { get; }

        Task<T> GetByIdAsync(long id);

        Task<T> InsertAsync(T entity);

        Task<IEnumerable<T>> InsertCollectionAsync(IEnumerable<T> entities);

        //Task<IEnumerable<T>> BulkInsertAsync(IEnumerable<T> entities);
    }
}
