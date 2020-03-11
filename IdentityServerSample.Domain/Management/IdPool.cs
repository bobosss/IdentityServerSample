using Allweb.Core.Common.Core;
using System.Runtime.Serialization;

namespace Auditor.Business.Models
{
    /// <summary>
    /// IdPool Business Model
    /// </summary>
    [DataContract]
    public class IdPool : EntityBase
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// RandomNum 
        /// </summary>
        [DataMember]
        public string RandomNum { get; set; }

        /// <summary>
        /// RandomNum 
        /// </summary>
        [DataMember]
        public bool Assigned { get; set; }
    }
}
