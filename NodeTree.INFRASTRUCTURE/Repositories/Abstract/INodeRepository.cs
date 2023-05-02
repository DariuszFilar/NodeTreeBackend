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
    }
}
