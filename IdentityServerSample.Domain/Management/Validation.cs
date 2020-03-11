using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Allweb.Core.Common.Core;

namespace Auditor.Business.Models
{
    /// <summary>
    /// Validation Business entity
    /// </summary>
    [DataContract]
    [NotMapped]
    public class Validation : EntityBase
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Validation Error
        /// </summary>
        [DataMember]
        public string ValidationError { get; set; }
    }
}
