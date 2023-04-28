using NodeTree.INFRASTRUCTURE.Requests;

namespace NodeTree.INFRASTRUCTURE.Services.Abstract
{
    public interface INodeService
    {
        Task CreateNodeAsync(CreateNodeRequest request);
        Task DeleteNodeAsync(DeleteNodeRequest request);
        Task RenameNodeAsync(RenameNodeRequest request);
    }
}
