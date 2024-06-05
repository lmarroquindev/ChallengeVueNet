using BackendChallenge.Core.Interfaces.Repositories;

namespace BackendChallenge.Data.Repositories
{
    /// <summary>
    /// A concrete implementation of the IBaseRepository interface that provides
    /// methods for adding, retrieving, removing, and saving entities in the database.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class BaseRepository<TKey, TEntity> : IBaseRepository<TKey, TEntity> where TEntity : class
    {
        protected readonly ChallengeVueNetContext _dbContext;

        protected BaseRepository(ChallengeVueNetContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TEntity entidad)
        {
            await _dbContext.Set<TEntity>().AddAsync(entidad);
        }

        public abstract Task<TEntity> GetByIdAsync(TKey id, bool? tracking = true);

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public void RemoveAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }
    }
}
