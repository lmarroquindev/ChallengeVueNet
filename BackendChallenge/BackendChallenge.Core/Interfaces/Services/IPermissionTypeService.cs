using BackendChallenge.Core.Dtos.Output;

namespace BackendChallenge.Core.Interfaces.Services
{
    /// <summary>
    /// Interface that contains the definition of service methods for the <see cref="PermissionType"/> entity.
    /// </summary>
    public interface IPermissionTypeService
    {
        /// <summary>
        /// Retrieves an object of type <see cref="PermissionTypeOutputDto"/> by filtering it by its unique identifier from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the permission type.</param>
        /// <returns></returns>
        Task<PermissionTypeOutputDto> GetByIdAsync(int id);
        /// <summary>
        /// Retrieves a list of objects of type <see cref="PermissionTypeOutputDto"/> from the database.
        /// </summary>
        /// <returns></returns>
        Task<List<PermissionTypeOutputDto>> GetListAsync();
    }
}
