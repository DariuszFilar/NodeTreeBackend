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
        private readonly ITreeRepository _treeRepository;
        public NodeService(INodeRepository nodeRepository, 
            ITreeRepository treeRepository)
        {
            _nodeRepository = nodeRepository;
            _treeRepository = treeRepository;
        }
        public async Task CreateNodeAsync(CreateNodeRequest request)
        {
            Node parent = await _nodeRepository.GetByIdAsync(request.ParentId);

            if (parent == null)
            {
                throw new SecureException();
            }

            Node Tree = await _treeRepository.GetTreeByTreeNameAsync(request.TreeName);
            List<Node> NodeSiblings = await _nodeRepository.GetAllSiblingsByParentIdAsync(request.ParentId);
            if (NodeSiblings.Any(n => n.Name == request.NodeName))
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

        public async Task DeleteNodeAsync(DeleteNodeRequest request)
        {
            Node node = await _nodeRepository.GetNodeWithChildrenByNodeIdAndTreeName(request.NodeId, request.TreeName);
            if (node == null || node.Children.Any())
            {
                throw new SecureException();
            }

            await _nodeRepository.RemoveAsync(node);
        }

        public async Task RenameNodeAsync(RenameNodeRequest request)
        {
            Node node = await _nodeRepository.GetByIdAsync(request.NodeId);
            if (node == null)
            {
                throw new SecureException();
            }

            node.Name = request.NewNodeName;
            await _nodeRepository.UpdateAsync(node);
        }
    }
}
