using System.Runtime.Serialization;

namespace Auditor.Business.Models
{
    /// <summary>
    /// Person Email Business entity
    /// </summary>
    [DataContract]
    public class PersonEmail : EntityWithError
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
        /// Email Id (foreign key)
        /// </summary>
        [DataMember]
        public int EmailId { get; set; }

        /// <summary>
        /// Person navigational property
        /// </summary>
        public virtual Person Person { get; set; }

        /// <summary>
        /// Email navigational property
        /// </summary>
        [DataMember]
        public Email Email { get; set; }
    }
    
}
