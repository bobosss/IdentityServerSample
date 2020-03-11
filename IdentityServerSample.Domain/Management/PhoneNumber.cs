using System.Runtime.Serialization;

namespace Auditor.Business.Models
{
    /// <summary>
    /// Stores phone numbers etc for which ever entity needs it 
    /// </summary>
    /// <remarks>
    /// Proper Datacontract Namespace is located in AssemblyInfo.cs file. Namespace is equal to relative Client Side Model
    /// </remarks>
    [DataContract]
    public class PhoneNumber : EntityWithError
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Phone Number Type
        /// </summary>
        /// <remarks>
        /// from lookup
        /// </remarks>
        [DataMember]
        public string PhoneNumberType { get; set; }

        /// <summary>
        /// Number
        /// </summary>
        [DataMember]
        public string Number { get; set; }
    }
}
