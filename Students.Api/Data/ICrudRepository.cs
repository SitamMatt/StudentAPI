using System.Collections.Generic;
using System.Threading.Tasks;

namespace Students.Data
{
    public interface ICrudRepository<TEntity> where TEntity : class
    {
        Task<TEntity> FindAsync(long id);
        Task<TEntity> SaveAsync(TEntity entity);
        void Delete(TEntity entity);
        Task CommitAsync();
        Task<List<TEntity>> FindAllAsync();
    }
}