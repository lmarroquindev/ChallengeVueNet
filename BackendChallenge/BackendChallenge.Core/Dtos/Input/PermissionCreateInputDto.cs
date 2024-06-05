using BackendChallenge.Core.Entities;

namespace BackendChallenge.Core.Dtos.Input
{
    /// <summary>
    /// DTO that contains the input data for creating a new record for the <see cref=“Permission”/> entity.
    /// </summary>
    public class PermissionCreateInputDto
    {
        /// <inheritdoc cref="Permission.FirstName"/>
        public string FirstName { get; set; }

        /// <inheritdoc cref="Permission.LastName"/>
        public string LastName { get; set; }

        /// <inheritdoc cref="Permission.PermissionTypeId"/>
        public int PermissionTypeId { get; set; }

        /// <inheritdoc cref="Permission.PermissionDate"/>
        public DateTime PermissionDate { get; set; }
    }
}
