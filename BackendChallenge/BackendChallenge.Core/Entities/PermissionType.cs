namespace BackendChallenge.Core.Entities
{
    /// <summary>
    /// Represents the type of permission available.
    /// </summary>
    public class PermissionType
    {
        #region Properties
        /// <summary>
        /// Unique identifier for the permission type.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Description of the permission type.
        /// </summary>
        public string Description { get; set; }
        #endregion
    }
}
