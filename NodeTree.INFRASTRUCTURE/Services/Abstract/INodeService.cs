using NodeTree.INFRASTRUCTURE.Requests;

namespace NodeTree.INFRASTRUCTURE.Services.Abstract
{
    public interface INodeService
    {
        Task AddNodeAsync(CreateNodeRequest request);
    }
}
