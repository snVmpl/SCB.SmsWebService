using Microsoft.EntityFrameworkCore;
using SCB.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCB.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DatabaseContext Context;

        public BaseRepository(DatabaseContext context)
        {
            Context = context;
        }

        public IQueryable<T> Entities => Context.Set<T>();

        public virtual async Task<T> GetByIdAsync(long id)
        {
            var result = await ((DbSet<T>)Entities).FindAsync(id);
            return result;
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            var result = await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return result.Entity;
        }

        public virtual async Task<IEnumerable<T>> InsertCollectionAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                await Context.AddAsync(entity);
            }

            await Context.SaveChangesAsync();
            return entities;
        }

        // TODO here can be implemented bulk insert method
        //public Task<IEnumerable<T>> BulkInsertAsync(IEnumerable<T> entities)
        //{
        //}
    }
}
