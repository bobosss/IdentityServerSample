using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Auditor.Business.Models
{
    /// <summary>
    /// Data Contract namespacing declared in AssemblyInfo.cs. Has to be the same with server side counterpart.
    /// </summary>
    [DataContract]
    public class LoginInfo
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string AuthenticationMethod { get; set; }
        public string IdentityProvider { get; set; }
        public List<Claim> Claims { get; set; }
        public List<string> Errors { get; set; }
        public bool HasErrors
        {
            get { return (Errors.Count > 0); }
            set { }
        }
    }
}
