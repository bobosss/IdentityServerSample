using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Auditor.Security.Common.Models;
using System.Collections.ObjectModel;

namespace Auditor.Business.Models
{
    /// <summary>
    /// HelpDesk Issue Entity
    /// </summary>
    [DataContract]
    public class Issue : EntityWithError, IPermissions
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Subject
        /// </summary>
        [DataMember]
        public string Subject { get; set; }
        /// <summary>
        /// UNIC
        /// </summary>
        [DataMember]
        public string UNIC { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        ///Answer
        /// </summary>
        [DataMember]
        public string Answer { get; set; }

        /// <summary>
        ///InFaq
        /// </summary>
        [DataMember]
        public bool InFaq { get; set; }

        /// <summary>
        ///Published
        /// </summary>
        [DataMember]
        public bool Published { get; set; }
        /// <summary>
        /// Person Id
        /// </summary>
        [DataMember]
        public int? PersonId { get; set; }

        /// <summary>
        /// AnonUser Id
        /// </summary>
        [DataMember]
        public int? AnonUserId { get; set; }

        /// <summary>
        /// Order
        /// </summary>
        [DataMember]
        public int? Order { get; set; }

        /// <summary>
        /// Person navigation property
        /// </summary>
        [DataMember]
        public virtual Person Person { get; set; }

        /// <summary>
        /// AnonUser  navigation property
        /// </summary>
        [DataMember]
        public AnonUser AnonUser { get; set; }

        /// <summary>
        /// IssueFile
        /// </summary>
        [DataMember]
        public Collection<IssueFiles> IssueFiles { get; set; }

        /// <summary>
        /// Permissions.
        /// </summary>
        [DataMember]
        [NotMapped]
        public ICollection<RolePermission> Permissions { get; set; }
    }

    /// <summary>
    /// IssueFiles
    /// </summary>
    [DataContract]
    public class IssueFiles : EntityWithError
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Document Type
        /// </summary>
        [DataMember]
        public int DocumentType { get; set; }

        /// <summary>
        /// Document Name
        /// </summary>
        [DataMember]
        public string DocumentName { get; set; }

        /// <summary>
        /// IssueId
        /// </summary>
        [DataMember]
        public int IssueId { get; set; }

        /// <summary>
        /// File Data Id
        /// </summary>
        [DataMember]
        public int FileDataId { get; set; }

        /// <summary>
        /// Issue
        /// </summary>
        public virtual Issue Issue { get; set; }

        /// <summary>
        /// File Data
        /// </summary>
        [DataMember]
        public virtual FileData FileData { get; set; }
    }
}
