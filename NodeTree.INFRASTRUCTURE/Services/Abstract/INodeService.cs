using NodeTree.INFRASTRUCTURE.Requests;

namespace NodeTree.INFRASTRUCTURE.Services.Abstract
{
    /// <summary>
    /// Interface for a node service.
    /// </summary>
    public interface INodeService
    {
        /// <summary>
        /// Creates a new node in the tree.
        /// </summary>
        /// <param name="request">The request containing the name, treename and parent node ID of the new node.</param>
        Task CreateNodeAsync(CreateNodeRequest request);

        /// <summary>
        /// Deletes a node from the tree.
        /// </summary>
        /// <param name="request">The request containing the ID of the node to delete and tree name.</param>
        Task DeleteNodeAsync(DeleteNodeRequest request);

        /// <summary>
        /// Renames a node in the tree.
        /// </summary>
        /// <param name="request">The request containing the ID of the node to rename and its new name.</param>
        Task RenameNodeAsync(RenameNodeRequest request);
    }
}
