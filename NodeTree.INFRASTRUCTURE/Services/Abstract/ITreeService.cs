using NodeTree.DB.Entities;

namespace NodeTree.INFRASTRUCTURE.Services.Abstract
{
    /// <summary>
    /// Interface for a tree service.
    /// </summary>
    public interface ITreeService
    {
        /// <summary>
        /// Gets the tree with the given name.
        /// </summary>
        /// <param name="treeName">The name of the tree to retrieve.</param>
        /// <returns>The tree with the given name.</returns>
        Task<Node> GetTreeAsync(string treeName);
    }
}
