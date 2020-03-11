using Auditor.Security;
using Auditor.Security.Common.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Auditor.Security.Stores
{
    public class UserStore :
        UserStore<ApplicationUser>
    {
        public UserStore(SecurityDbContext context) : base(context)
        {

        }
    }
}