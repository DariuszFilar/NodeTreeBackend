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
    }
}
