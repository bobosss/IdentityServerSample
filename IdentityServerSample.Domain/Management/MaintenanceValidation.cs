using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Allweb.Core.Common.Core;

namespace Auditor.Business.Models
{
    /// <summary>
    /// Maintenance Validation Business entity
    /// </summary>
    [DataContract]
    [NotMapped]
    public class MaintenanceValidation : EntityBase
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Maintenance Id (foreign key)
        /// </summary>
        [DataMember]
        public int MaintenanceId { get; set; }

        /// <summary>
        /// Validation Id (foreign key)
        /// </summary>
        [DataMember]
        public int ValidationId { get; set; }

        /// <summary>
        /// Maintenance navigational property
        /// </summary>
        public virtual Maintenance Maintenance { get; set; }

        /// <summary>
        /// Validation navigational property
        /// </summary>
        [DataMember]
        public Validation Validation { get; set; }
    }
}
