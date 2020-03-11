using Microsoft.AspNetCore.Identity;

namespace Auditor.Security.Common.Models
{

    /// <summary>
    /// Custom user login.
    /// </summary>
    /// <remarks>
    /// Specify Int32 as primary key.
    /// </remarks>
    public class ApplicationUserLogin: IdentityUserLogin<int>
    {
    }
}
