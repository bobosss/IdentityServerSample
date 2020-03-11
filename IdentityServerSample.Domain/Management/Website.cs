using System.Runtime.Serialization;

namespace Auditor.Business.Models
{
    /// <summary>
    /// Website Business entity
    /// </summary>
    [DataContract]
    public class Website : EntityWithError
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Website string
        /// </summary>
        [DataMember]
        public string Url { get; set; }
    }
}
