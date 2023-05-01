using NodeTree.DB.Entities;

namespace NodeTree.INFRASTRUCTURE.Repositories.Abstract
{
    /// <summary>
    /// Interface for interacting with the "Node" entity in the database.
    /// </summary>
    public interface INodeRepository : IRepository<Node>
    {
        /// <summary>
        /// Gets all sibling nodes of a given parent node.
        /// </summary>
        /// <param name="parentId">The ID of the parent node to get siblings for.</param>
        /// <returns>A list of sibling nodes of the specified parent node.</returns>
        Task<List<Node>> GetAllSiblingsByParentIdAsync(long parentId);

        /// <summary>
        /// Gets a node with all of its children by its ID and the name of the tree it belongs to.
        /// </summary>
        /// <param name="nodeId">The ID of the node to get.</param>
        /// <param name="treeName">The name of the tree the node belongs to.</param>
        /// <returns>The node with all its children, or null if no node with the specified ID was found.</returns>
        Task<Node> GetNodeWithChildrenByNodeIdAndTreeName(long nodeId, string treeName);
    }
}
