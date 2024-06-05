using BackendChallenge.Core.Entities;

namespace BackendChallenge.Core.Dtos.Output
{
    /// <summary>
    /// Output Dto that represent to <see cref="Permission"/> entity.
    /// </summary>
    public class PermissionOutputDto
    {
        /// <inheritdoc cref="Permission.Id"/>
        public int Id { get; set; }

        /// <inheritdoc cref="Permission.FirstNameEmployee"/>
        public string FirstNameEmployee { get; set; }

        /// <inheritdoc cref="Permission.LastNameEmployee"/>
        public string LastNameEmployee { get; set; }

        /// <inheritdoc cref="Permission.PermissionTypeId"/>
        public int PermissionTypeId { get; set; }

        /// <inheritdoc cref="Permission.PermissionDate"/>
        public DateTime PermissionDate { get; set; }

        /// <summary>
        /// Permission Type assigned to this Permission.
        /// </summary>
        public PermissionTypeOutputDto PermissionType { get; set; }
    }
}
