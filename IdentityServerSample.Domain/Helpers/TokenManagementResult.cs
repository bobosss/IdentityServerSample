using System.Collections.Generic;
using System.Linq;
using Allweb.Core.Common.Core;

namespace Auditor.Business.Models
{
    public class TokenManagementResult : ApplicationUserModel
    {

        public IEnumerable<string> Errors { get; set; }

        public string Token { get; set; }

        public bool IsSuccess
        {
            get { return Errors == null || !Errors.Any(); }
            set { }
        }
    }
}