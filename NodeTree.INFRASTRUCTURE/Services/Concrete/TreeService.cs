using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.Repositories.Abstract;
using NodeTree.INFRASTRUCTURE.Services.Abstract;

namespace NodeTree.INFRASTRUCTURE.Services.Concrete
{
    public class TreeService : ITreeService
    {
        private readonly ITreeRepository _treeRepository;
        public TreeService(ITreeRepository treeRepository)
        {
            _treeRepository = treeRepository;
        }

        public async Task<Node> GetTreeAsync(string treeName)
        {
            Node tree = await _treeRepository.GetTreeByTreeNameAsync(treeName);
            if (tree != null)
            {
                return tree;
            }

            tree = new Node()
            {
                Name = treeName,
                TreeName = treeName
            };

            await _treeRepository.AddAsync(tree);

            return tree;
        }
    }
}
