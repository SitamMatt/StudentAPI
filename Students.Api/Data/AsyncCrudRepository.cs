using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Students.Data
{
    public class AsyncCrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;

        public AsyncCrudRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<List<TEntity>> FindAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> FindAsync(long id)
        {
            return await _context.FindAsync<TEntity>(id);
        }

        public async Task<TEntity> SaveAsync(TEntity entity)
        {
            var set = _context.Set<TEntity>();
            if (await set.ContainsAsync(entity))
                set.Update(entity);
            else
                await set.AddAsync(entity);

            return entity;
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}