using BackendChallenge.Core.Dtos.Input;
using BackendChallenge.Core.Dtos.Output;
using BackendChallenge.Core.Entities;

namespace BackendChallenge.Core.Interfaces.Services
{
    /// <summary>
    /// Interface that contains the definition of service methods for the <see cref="Permission"/> entity.
    /// </summary>
    public interface IPermissionService
    {
        /// <summary>
        /// Retrieves an object of type <see cref="PermissionOutputDto"/> by filtering it by its unique identifier from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the permission type.</param>
        /// <returns></returns>
        Task<PermissionOutputDto> GetByIdAsync(int id);
        /// <summary>
        /// Retrieves a list of objects of type <see cref="PermissionOutputDto"/> from the database.
        /// </summary>
        /// <returns></returns>
        Task<List<PermissionOutputDto>> GetListAsync();
        /// <summary>
        /// Creates a new <see cref="Permission"/> record in the database.
        /// </summary>
        /// <param name="input">The data to create the permission.</param>
        /// <returns>A task that represents the asynchronous operation of creating a permission.</returns>
        Task<PermissionOutputDto> CreateAsync(PermissionCreateInputDto input);

        /// <summary>
        /// Modifies an existing <see cref="Permission"/> record in the database.
        /// </summary>
        /// <param name="input">The data to update the permission.</param>
        /// <returns>A task that represents the asynchronous operation of updating a permission.</returns>
        Task<PermissionOutputDto> UpdateAsync(PermissionUpdateInputDto input);

        /// <summary>
        /// Deletes an existing <see cref="Permission"/> record from the database.
        /// </summary>
        /// <param name="id">The identifier of the permission to delete.</param>
        /// <returns>A task that represents the asynchronous operation of deleting a permission.</returns>
        Task DeleteAsync(int id);
    }
}
