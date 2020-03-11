using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Auditor.Security.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auditor.Business.Models
{
    /// <summary>
    /// LookupTypes Business Model
    /// </summary>
    [DataContract]
    public class LookupType : EntityWithError, IPermissions
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Lookup type code
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// Lookup Type Description
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Lookup Type Description_el
        /// </summary>
        [DataMember]
        public string Description_el { get; set; }

        /// <summary>
        /// Look up values per look up type
        /// </summary>
        [DataMember]
        public Collection<Lookup> Lookups { get; set; }

        /// <summary>
        /// Permissions
        /// </summary>
        [DataMember]
        [NotMapped]
        public ICollection<RolePermission> Permissions { get; set; }
    }
}
