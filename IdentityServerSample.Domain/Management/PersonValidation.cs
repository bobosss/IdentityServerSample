using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Allweb.Core.Common.Core;

namespace Auditor.Business.Models
{
    /// <summary>
    /// Person Validation Business entity
    /// </summary>
    [DataContract]
    [NotMapped]
    public class PersonValidation : EntityBase
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Person Id (foreign key)
        /// </summary>
        [DataMember]
        public int PersonId { get; set; }

        /// <summary>
        /// Validation Id (foreign key)
        /// </summary>
        [DataMember]
        public int ValidationId { get; set; }

        /// <summary>
        /// Person navigational property
        /// </summary>
        public virtual Person Person { get; set; }

        /// <summary>
        /// Validation navigational property
        /// </summary>
        [DataMember]
        public Validation Validation { get; set; }
    }
}
