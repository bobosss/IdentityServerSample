using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Auditor.Security.Common.Models;

namespace Auditor.Business.Models
{
    /// <summary>
    /// IdPool Business Model
    /// </summary>
    [DataContract]
    public class InformationDocument : EntityWithError, IPermissions
    {

        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Title  
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Description  
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Category  
        /// </summary>
        [DataMember]
        public string Category { get; set; }

        /// <summary>
        /// File Id
        /// </summary>
        [DataMember]
        public int? FileId { get; set; }

        /// <summary>
        /// Degree Field
        /// </summary>
        [DataMember]
        public virtual FileData File { get; set; }


        /// <summary>
        /// Permissions.
        /// </summary>
        [DataMember]
        [NotMapped]
        public ICollection<RolePermission> Permissions { get; set; }
    }
}
