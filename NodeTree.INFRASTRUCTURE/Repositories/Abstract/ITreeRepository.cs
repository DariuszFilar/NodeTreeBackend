using NodeTree.DB.Entities;

namespace NodeTree.INFRASTRUCTURE.Repositories.Abstract
{
    /// <summary>
    /// Interface for interacting with a repository for trees of nodes.
    /// </summary>
    public interface ITreeRepository : IRepository<Node>
    {
        /// <summary>
        /// Retrieves a tree of nodes with a given name.
        /// </summary>
        /// <param name="treeName">The name of the tree to retrieve.</param>
        /// <returns>The root node of the tree with the specified name.</returns>
        Task<Node> GetTreeByTreeNameAsync(string treeName);
    }
}
