using Microsoft.EntityFrameworkCore;
using NodeTree.DB;
using NodeTree.INFRASTRUCTURE.Repositories.Abstract;

namespace NodeTree.INFRASTRUCTURE.Repositories.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly INodeTreeDbContext _dbContext;

        public Repository(INodeTreeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<TEntity> GetByIdAsync(long id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            _ = await _dbContext.Set<TEntity>().AddAsync(entity);
            _ = await _dbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _ = _dbContext.Set<TEntity>().Update(entity);
            _ = await _dbContext.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            _ = _dbContext.Set<TEntity>().Remove(entity);
            _ = await _dbContext.SaveChangesAsync();
        }
    }
}
