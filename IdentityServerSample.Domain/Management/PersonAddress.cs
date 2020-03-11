using System.Runtime.Serialization;

namespace Auditor.Business.Models
{
    /// <summary>
    /// Person Address Business entity
    /// </summary>
    [DataContract]
    public class PersonAddress : EntityWithError
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
        /// Address Id (foreign key)
        /// </summary>
        [DataMember]
        public int AddressId { get; set; }

        /// <summary>
        /// Person navigational property
        /// </summary>
        public virtual Person Person { get; set; }

        /// <summary>
        /// Address navigational property
        /// </summary>
        [DataMember]
        public Address Address { get; set; }
    }

}
