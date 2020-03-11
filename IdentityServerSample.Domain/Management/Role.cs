using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Auditor.Business.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    [NotMapped]
    public class Role
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is super admin.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is super admin; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsSuperAdmin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is admin.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is super admin; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance can manage.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance can manage; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool CanManage { get; set; }
    }
}
