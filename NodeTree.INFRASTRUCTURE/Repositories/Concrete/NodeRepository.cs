using Microsoft.EntityFrameworkCore;
using NodeTree.DB;
using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.Repositories.Abstract;

namespace NodeTree.INFRASTRUCTURE.Repositories.Concrete
{
    public class NodeRepository : Repository<Node>, INodeRepository
    {
        private readonly NodeTreeDbContext _context;
        public NodeRepository(NodeTreeDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Node>> GetAllSiblingsByParentIdAsync(long parentId)
        {
            return await _context.Nodes
                .Where(n => n.ParentId == parentId)
                .ToListAsync();
        }        

        public async Task<Node> GetNodeWithChildrenByNodeIdAndTreeName(long nodeId, string treeName)
        {
            return await _context.Nodes
                .Include(n => n.Children)
                .FirstOrDefaultAsync(n => n.NodeId == nodeId && n.TreeName == treeName);
        }                
    }
}
