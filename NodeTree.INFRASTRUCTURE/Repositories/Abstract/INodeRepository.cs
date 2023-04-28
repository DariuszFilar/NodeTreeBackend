using NodeTree.DB.Entities;

namespace NodeTree.INFRASTRUCTURE.Repositories.Abstract
{
    public interface INodeRepository : IRepository<Node>
    {
        Task<List<Node>> GetAllSiblingsByParentIdAsync(long parentId);        
        Task<Node> GetNodeWithChildrenByNodeIdAndTreeName(long nodeId, string treeName);
    }
}
