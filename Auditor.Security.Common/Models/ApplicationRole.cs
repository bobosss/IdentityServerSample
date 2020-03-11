using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Auditor.Security.Common.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
        }

        public ApplicationRole(string name, string code)
        {
            Name = name;
            Code = code;
        }

        [Required]
        public string Code { get; set; }

        [Required]
        public bool? Administrator { get; set; }

        [Required]
        public bool? Manager { get; set; }
    }
}
