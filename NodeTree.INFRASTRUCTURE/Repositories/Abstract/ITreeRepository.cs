using NodeTree.DB.Entities;

namespace NodeTree.INFRASTRUCTURE.Repositories.Abstract
{
    public interface ITreeRepository : IRepository<Node>
    {
        Task<Node> GetTreeByTreeNameAsync(string treeName);
    }
}
