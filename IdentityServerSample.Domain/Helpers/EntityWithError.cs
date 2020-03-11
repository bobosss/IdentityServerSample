using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using Allweb.Core.Common.Core;

namespace Auditor.Business.Models
{
    /// <summary>
    /// EntityWithError
    /// </summary>
    [DataContract]
    public class EntityWithError : EntityBase
    {
        /// <summary>
        /// Gets a value indicating whether this instance has errors.
        /// </summary>
        [IgnoreDataMember]
        [NotMapped]
        public bool HasErrors => Errors != null && Errors.Any();

        /// <summary>
        /// Errors
        /// </summary>
        [DataMember]
        [NotMapped]
        public Collection<AuditorException> Errors { get; set; }
    }
}
