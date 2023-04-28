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

        public async Task<Node> GetTreeByTreeNameAsync(string treeName)
        {
            Node parent = await _context.Nodes
                .Include(n => n.Children)
                .Where(n => n.TreeName == treeName && n.ParentId == null)
                .FirstOrDefaultAsync();

            if (parent != null)
            {
                LoadChildrenRecursively(parent);
            }

            return parent;
        }

        public async Task<Node> GetNodeWithChildrenByNodeId(long nodeId)
        {
            return await _context.Nodes
                .Include(n => n.Children)
                .FirstOrDefaultAsync(n => n.NodeId == nodeId);
        }

        private void LoadChildrenRecursively(Node node)
        {
            if (node == null) return;

            foreach (var child in node.Children)
            {
                _context.Entry(child).Reference(n => n.Parent).Load();
                _context.Entry(child).Collection(n => n.Children).Load();
                LoadChildrenRecursively(child);
            }
        }
    }
}
