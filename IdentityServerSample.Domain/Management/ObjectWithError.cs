using System.Collections.Generic;
using System.Linq;
using Allweb.Core.Common.Core;
using Auditor.Business.Models;

namespace Auditor.Bussness.Models
{
    /// <summary>
    /// ObjectWithError
    /// </summary>
    public class ObjectWithError : ObjectBase
    {
        /// <summary>
        /// Gets a value indicating whether this instance has errors
        /// </summary>
        public bool HasErrors => Errors != null && Errors.Any();

        /// <summary>
        /// Errors
        /// </summary>
        public ICollection<AuditorException> Errors { get; set; }
    }
}
