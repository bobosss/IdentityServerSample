using Auditor.Common.Enums;

namespace Auditor.Security.Common.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Allweb.Core.Common.Core.EntityBase" />
    public class RolePermission
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the permission identifier.
        /// </summary>
        public int PermissionId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public PermissionType Type { get; set; }

        /// <summary>
        /// Gets or sets if this instance has create permission.
        /// </summary>
        public bool? Create { get; set; }

        /// <summary>
        /// Gets or sets if this instance has read permission.
        /// </summary>
        public bool? Read { get; set; }

        /// <summary>
        /// Gets or sets if this instance has update permission.
        /// </summary>
        public bool? Update { get; set; }

        /// <summary>
        /// Gets or sets if this instance has delete permission.
        /// </summary>
        public bool? Delete { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        public ApplicationRole Role { get; set; }

        /// <summary>
        /// Gets or sets the permission.
        /// </summary>
        public Permission Permission { get; set; }
    }
}
