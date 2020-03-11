using Microsoft.AspNetCore.Identity;

namespace Auditor.Security.Common.Models
{
    /// <summary>
    /// Custom user role.
    /// </summary>
    /// <remarks>
    /// Specify Int32 as primary key.
    /// </remarks>
    public class ApplicationUserRole: IdentityUserRole<int>
    {
    }
}
