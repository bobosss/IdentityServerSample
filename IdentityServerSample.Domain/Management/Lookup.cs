using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auditor.Business.Models
{
    /// <summary>
    /// Lookups Business Model
    /// </summary>
    [DataContract]
    public class Lookup : EntityWithError
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Lookup Type Id
        /// </summary>
        [DataMember]
        public int LookupTypeId { get; set; }

        /// <summary>
        /// Lookup Code
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// Title_en
        /// </summary>
        [DataMember]
        public string Title_en { get; set; }

        /// <summary>
        /// Title_el
        /// </summary>
        [DataMember]
        public string Title_el { get; set; }

        /// <summary>
        /// Lookup Description
        /// </summary>
        [DataMember]
        public string Description_en { get; set; }

        /// <summary>
        /// Lookup Title
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Lookup Description_el
        /// </summary>
        [DataMember]
        public string Description_el { get; set; }
        
        /// <summary>
        /// Lookup Parent Code, in case of nested lookup
        /// </summary>
        [DataMember]
        public int? ParentId { get; set; }

        /// <summary>
        /// Lookup Type navigation property
        /// </summary>
        public virtual LookupType LookupType { get; set; }

        /// <summary>
        /// Lookup Parent navigation property
        /// </summary>
        public virtual Lookup Parent { get; set; }

        /// <summary>
        /// Lookup Parent navigation property
        /// </summary>
        [DataMember]
        [NotMapped]
        public string ParentDescription { get; set; }

        /// <summary>
        /// Lookup Children navigation property
        /// </summary>
        [DataMember]
        public Collection<Lookup> Children { get; set; }
    }
}
