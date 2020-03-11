using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Auditor.Business.Models
{
    /// <summary>
    /// Wrapper class for <see cref="IdentityResult">IdentityResult</see> to be able to Serialize and tranfer over the WCF wire
    /// </summary>
    public class AuditorIdentityResult : TokenManagementResult
    {
        public bool Succeeded { get; set; }

        public int PersonId { get; set; }

    }
}
