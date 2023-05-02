using Microsoft.EntityFrameworkCore;
using NodeTree.DB;
using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.Repositories.Abstract;

namespace NodeTree.INFRASTRUCTURE.Repositories.Concrete
{
    public class TreeRepository : Repository<Node>, ITreeRepository
    {
        private readonly INodeTreeDbContext _context;
        public TreeRepository(INodeTreeDbContext context) : base(context)
        {
            _context = context;
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
