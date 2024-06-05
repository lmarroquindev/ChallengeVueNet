namespace BackendChallenge.Core.Interfaces.Repositories
{
    /// <summary>
    /// Base repository to facilitate the creation of other repositories.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IBaseRepository<TKey, TEntity> where TEntity : class
    {
        /// <summary>
        /// Adds an entity to the database.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task that represents the asynchronous add operation.</returns>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Retrieves an entity by its ID from the database.
        /// </summary>
        /// <param name="id">The primary key of the entity to retrieve.</param>
        /// <returns>A task that represents the asynchronous retrieval operation.</returns>
        Task<TEntity> GetByIdAsync(TKey id, bool? tracking = true);

        /// <summary>
        /// Removes an entity from the database.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        Task RemoveAsync(TEntity entity);

        /// <summary>
        /// Saves all changes made to the entities in the database.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        Task SaveChangesAsync();
    }

}
