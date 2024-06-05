using BackendChallenge.Core.Entities;

namespace BackendChallenge.Core.Dtos.Output
{
    /// <summary>
    /// Output Dto that represent to <see cref="PermissionType"/> entity.
    /// </summary>
    public class PermissionTypeOutputDto
    {
        /// <inheritdoc cref="PermissionType.Id"/>
        public int Id { get; set; }

        /// <inheritdoc cref="PermissionType.Description"/>
        public string Description { get; set; }
    }
}
