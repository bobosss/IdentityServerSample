using System.Collections.Generic;
using Auditor.Security.Common.Models;

namespace Auditor.Business.Models
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPermissions
    {
        /// <summary>
        /// Gets or sets the permissions.
        /// </summary>
        ICollection<RolePermission> Permissions { get; set; }
    }
}