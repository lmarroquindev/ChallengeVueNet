using BackendChallenge.Core.Entities;

namespace BackendChallenge.Core.Interfaces.Repositories
{
    /// <summary>
    /// Interface that contains the definition of methods for interacting with the database related to the <see cref="PermissionType"/> entity.
    /// </summary>
    public interface IPermissionTypeRepository : IBaseRepository<int, PermissionType>
    {
        /// <summary>
        /// Retrieves a list of <see cref="PermissionType"/> objects from the database.
        /// </summary>
        /// <returns></returns>
        Task<List<PermissionType>> GetListAsync(bool? tracking = true);
    }
}
