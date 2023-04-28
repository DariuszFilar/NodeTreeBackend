using NodeTree.DB.Entities;

namespace NodeTree.INFRASTRUCTURE.Services.Abstract
{
    public interface ITreeService
    {
        Task<Node> GetTreeAsync(string treeName);
    }
}
