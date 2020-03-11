using Auditor.Security;
using Auditor.Security.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Auditor.Security.Stores
{
    public class RoleStore : RoleStore<ApplicationRole>
    {
        public RoleStore(SecurityDbContext context) : base(context) { }
    }
}