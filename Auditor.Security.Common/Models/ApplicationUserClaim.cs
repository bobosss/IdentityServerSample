using Microsoft.AspNetCore.Identity;

namespace Auditor.Security.Common.Models
{

    /// <summary>
    /// Custom user claim.
    /// </summary>
    /// <remarks>
    /// Specify Int32 as primary key.
    /// </remarks>
    public class ApplicationUserClaim: IdentityUserClaim<int>
    {
    }
}
