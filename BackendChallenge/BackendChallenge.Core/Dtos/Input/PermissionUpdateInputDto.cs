using BackendChallenge.Core.Entities;

namespace BackendChallenge.Core.Dtos.Input
{
    /// <summary>
    /// DTO that contains the input data for updating a new record for the <see cref=“Permission”/> entity.
    /// </summary>
    public class PermissionUpdateInputDto
    {
        /// <inheritdoc cref="Permission.FirstNameEmployee"/>
        public string? FirstNameEmployee { get; set; }

        /// <inheritdoc cref="Permission.LastNameEmployee"/>
        public string? LastNameEmployee { get; set; }

        /// <inheritdoc cref="Permission.PermissionTypeId"/>
        public int? PermissionTypeId { get; set; }

        /// <inheritdoc cref="Permission.PermissionDate"/>
        public DateTime? PermissionDate { get; set; }
    }
}
