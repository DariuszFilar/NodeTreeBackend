using NodeTree.DB.Entities;

namespace NodeTree.INFRASTRUCTURE.Repositories.Abstract
{
    public interface INodeRepository : IRepository<Node>
    {
        Task<List<Node>> GetAllSiblingsByParentIdAsync(long parentId);
        Task<Node> GetTreeByTreeNameAsync(string treeName);        
        Task<Node> GetNodeWithChildrenByNodeId(long nodeId);
    }
}
