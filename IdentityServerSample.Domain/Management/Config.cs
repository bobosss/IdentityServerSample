using System.Runtime.Serialization;

namespace Auditor.Business.Models
{
    /// <summary>
    /// Config Business entity
    /// </summary>
    [DataContract]
    public class Config : EntityWithError
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [DataMember]
        public string Key { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [DataMember]
        public string Value { get; set; }
    }
}
