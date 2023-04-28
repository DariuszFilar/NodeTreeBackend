using NodeTree.DB.Entities;
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
            if (request.ParentId != null)
            {
                List<Node> siblings = await _nodeRepository.GetAllSiblingsByParentIdAsync(request.ParentId.Value);
                if (siblings.Any(s => s.Name == request.Name))
                {
                    throw new Exception();
                }
            }

            Node node = new()
            {
                Name = request.Name                
            };

            if (request.ParentId != null)
            {
                node.ParentId = request.ParentId.Value;
            }

            await _nodeRepository.AddAsync(node);
        }
    }
}
