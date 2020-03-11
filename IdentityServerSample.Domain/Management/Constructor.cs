using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using Auditor.Security.Common.Models;

namespace Auditor.Business.Models
{
    /// <summary>
    /// Base class for all Constructor Types
    /// </summary>
    /// <remarks>
    /// Proper Datacontract Namespace is located in AssemblyInfo.cs file.
    /// Namespace is equal to relative Client Side Model.
    /// </remarks>
    [DataContract]
    public class Constructor : EntityWithError, IPermissions
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Επωνυμία Κατασκευαστή
        /// </summary>
        [DataMember]
        public string ConstructorsName { get; set; }

        /// <summary>
        /// Διεύθυνση Κατασκευαστή
        /// </summary>
        [DataMember]
        public string ConstructorsAddress { get; set; }

        /// <summary>
        /// Χώρα Προέλευσης Κατασκευαστή
        /// </summary>
        /// <remarks>
        /// from lookup CountryCode
        /// </remarks>
        [DataMember]
        public string ConstructorsCountry { get; set; }

        /// <summary>
        /// Κατάσταση A/R
        /// </summary>
        [DataMember]
        public bool? ConstructorsStatus { get; set; }

        /// <summary>
        /// ConstructorsSubmitted
        /// </summary>
        [DataMember]
        public bool? ConstructorsSubmitted { get; set; }

        /// <summary>
        /// ConstructorsDraftId
        /// </summary>
        [DataMember]
        public int? ConstructorsDraftId { get; set; }

        /// <summary>
        /// Validation Status
        /// </summary>
        [DataMember]
        [NotMapped]
        public int ValidationStatus { get; set; }

        /// <summary>
        /// Editable (auxiliary property)
        /// </summary>
        [DataMember]
        [NotMapped]
        public bool Editable { get; set; }

        /// <summary>
        /// ToSubmit (auxiliary property)
        /// </summary>
        [DataMember]
        [NotMapped]
        public bool ToSubmit { get; set; }

        /// <summary>
        /// EnabledStatus
        /// </summary>
        [DataMember]
        public bool? EnabledStatus { get; set; }

        /// <summary>
        /// Permissions
        /// </summary>
        [DataMember]
        [NotMapped]
        public ICollection<RolePermission> Permissions { get; set; }
    }
}
