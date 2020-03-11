using Auditor.Security.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Auditor.Business.Models
{
    /// <summary>
    /// File Data Business entity
    /// </summary>
    [DataContract]
    public class FileData : EntityWithError, IPermissions
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DataMember]
        public string FileName { get; set; }

        /// <summary>
        /// StreamId
        /// </summary>
        [DataMember]
        public string StreamId { get; set; }

        /// <summary>
        /// Extension
        /// </summary>
        [DataMember]
        public string Extension { get; set; }

        /// <summary>
        /// File Size
        /// </summary>
        [DataMember]
        public long FileSize { get; set; }

        /// <summary>
        /// Permissions.
        /// </summary>
        [DataMember]
        [NotMapped]
        public ICollection<RolePermission> Permissions { get; set; }
    }
}
