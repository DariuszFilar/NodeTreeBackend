using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NodeTree.DB.Entities;

namespace NodeTree.DB
{
    public interface INodeTreeDbContext
    {
        DbSet<Node> Nodes { get; set; }
        DbSet<ExceptionLog> ExceptionsLog { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
