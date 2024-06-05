using BackendChallenge.Core.Entities;

namespace BackendChallenge.Core.Interfaces.Repositories
{
    /// <summary>
    /// Interface that contains the definition of methods for interacting with the database related to the <see cref="Permission"/> entity.
    /// </summary>
    public interface IPermissionRepository : IBaseRepository<int, Permission>
    {
        /// <summary>
        /// Retrieves a list of <see cref="Permission"/> objects from the database.
        /// </summary>
        /// <returns></returns>
        Task<List<Permission>> GetListAsync(bool? tracking = true);
    }
}
