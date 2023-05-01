namespace NodeTree.INFRASTRUCTURE.Repositories.Abstract
{
    /// <summary>
    /// Interface for interacting with a generic repository for any entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity that the repository interacts with.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Retrieves an record with a given ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>The entity with the specified ID, or null if no entity with the specified ID was found.</returns>
        Task<TEntity> GetByIdAsync(long id);

        /// <summary>
        /// Retrieves all records of a given type.
        /// </summary>
        /// <returns>A collection of all entities of the type that the repository interacts with.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Adds a new record to the repository.
        /// </summary>
        /// <param name="entity">The entity to add to the repository.</param>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Updates an existing record in the repository.
        /// </summary>
        /// <param name="entity">The entity to update in the repository.</param>
        Task UpdateAsync(TEntity entity);

        // <summary>
        /// Removes an existing record from the repository.
        /// </summary>
        /// <param name="entity">The entity to remove from the repository.</param>
        Task RemoveAsync(TEntity entity);
    }
}
