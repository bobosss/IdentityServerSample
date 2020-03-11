using System.Runtime.Serialization;

namespace Auditor.Business.Models
{
    /// <summary>
    /// Email Business entity
    /// </summary>
    [DataContract]
    public class Email : EntityWithError
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
        public string EMail { get; set; }
    }
}
