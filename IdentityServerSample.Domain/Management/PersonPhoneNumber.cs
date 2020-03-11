using System.Runtime.Serialization;

namespace Auditor.Business.Models
{
    /// <summary>
    /// Person Phone Number Business entity
    /// </summary>
    [DataContract]
    public class PersonPhoneNumber : EntityWithError
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
        /// Phone Number Id (foreign key)
        /// </summary>
        [DataMember]
        public int PhoneNumberId { get; set; }

        /// <summary>
        /// Person navigational property
        /// </summary>
        public virtual Person Person { get; set; }

        /// <summary>
        /// Phone Number navigational property
        /// </summary>
        [DataMember]
        public PhoneNumber PhoneNumber { get; set; }
    }


}
