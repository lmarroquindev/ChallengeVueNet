using BackendChallenge.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace BackendChallenge.Core.Dtos.Input
{
    /// <summary>
    /// DTO that contains the input data for creating a new record for the <see cref=“Permission”/> entity.
    /// </summary>
    public class PermissionCreateInputDto
    {
        /// <inheritdoc cref="Permission.FirstNameEmployee"/>
        [Required(ErrorMessage = "The first name of employee is required.")]
        public string FirstNameEmployee { get; set; }

        /// <inheritdoc cref="Permission.LastNameEmployee"/>
        [Required(ErrorMessage = "The last name of employee is required.")]
        public string LastNameEmployee { get; set; }

        /// <inheritdoc cref="Permission.PermissionTypeId"/>
        [Required(ErrorMessage = "The permission type is required.")]
        public int PermissionTypeId { get; set; }

        /// <inheritdoc cref="Permission.PermissionDate"/>
        [Required(ErrorMessage = "The permission date is required.")]
        public DateTime PermissionDate { get; set; }
    }
}
