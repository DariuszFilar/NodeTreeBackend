using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.Exceptions;
using NodeTree.INFRASTRUCTURE.Repositories.Abstract;
using NodeTree.INFRASTRUCTURE.Requests;
using NodeTree.INFRASTRUCTURE.Services.Abstract;

namespace NodeTree.INFRASTRUCTURE.Services.Concrete
{
    public class NodeService : INodeService
    {
        private readonly INodeRepository _nodeRepository;
        public NodeService(INodeRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;
        }
        public async Task AddNodeAsync(CreateNodeRequest request)
        {
            Node parent = await _nodeRepository.GetByIdAsync(request.ParentId);

            if (parent == null)
            {
                throw new SecureException();
            }

            Node Tree = await _nodeRepository.GetTreeByTreeNameAsync(request.TreeName);
            List<Node> siblings = await _nodeRepository.GetAllSiblingsByParentIdAsync(request.ParentId);
            if (siblings.Any(s => s.Name == request.NodeName))
            {
                throw new Exception();
            }

            Node node = new()
            {
                Name = request.NodeName,
                ParentId = request.ParentId,
                TreeName = request.TreeName,
            };

            await _nodeRepository.AddAsync(node);
        }
    }
}
