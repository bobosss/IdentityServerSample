using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Auditor.Business.Models
{
    /// <summary>
    /// AnonUser Business entity
    /// </summary>
    [DataContract]
    public class AnonUser : EntityWithError
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        [DataMember]
        public string LastName { get; set; }


        /// <summary>
        /// Email
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [DataMember]
        public string Phone { get; set; }
    }
}
