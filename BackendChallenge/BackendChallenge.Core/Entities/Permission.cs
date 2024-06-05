namespace BackendChallenge.Core.Entities
{
    /// <summary>
    /// Represents an employee's permission request.
    /// </summary>
    public class Permission
    {
        #region Properties
        /// <summary>
        /// Unique identifier for the record.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First name of the employee.
        /// </summary>
        public string FirstNameEmployee { get; set; }

        /// <summary>
        /// Last name of the employee.
        /// </summary>
        public string LastNameEmployee { get; set; }

        /// <summary>
        /// Type of permission requested.
        /// </summary>
        public int PermissionTypeId { get; set; }

        /// <summary>
        /// Date of the permission.
        /// </summary>
        public DateTime PermissionDate { get; set; }
        #endregion

        #region Navigation Properties
        public PermissionType PermissionType { get; set; }
        #endregion
    }
}
