using Microsoft.AspNetCore.Identity;
using System;


namespace Auditor.Security.Common.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}


