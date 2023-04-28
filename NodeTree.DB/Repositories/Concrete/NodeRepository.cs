using NodeTree.DB.Entities;
using NodeTree.DB.Repositories.Abstract;

namespace NodeTree.DB.Repositories.Concrete
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
