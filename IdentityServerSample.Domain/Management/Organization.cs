using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Allweb.Core.Common.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using Auditor.Security.Common.Models;

namespace Auditor.Business.Models
{
    /// <summary>
    /// Base class for all Organization Types
    /// </summary>
    /// <remarks>
    /// Proper Datacontract Namespace is located in AssemblyInfo.cs file.
    /// Namespace is equal to relative Client Side Model.
    /// </remarks>
    [DataContract]
    public class Organization : EntityWithError, IPermissions
    {
        /// <summary>
        /// Primary key
    /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// CompanyTitle
        /// </summary>
        [DataMember]
        public string CompanyTitle { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        [DataMember]
        public string Street { get; set; }

        /// <summary>
        /// StreetNo
        /// </summary>
        [DataMember]
        public string StreetNo { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// PostCode
        /// </summary>
        [DataMember]
        public string PostCode { get; set; }

        /// <summary>
        /// VatNumber
        /// </summary>
        [DataMember]
        public string VatNumber { get; set; }
        /// <summary>
        /// Telephone
        /// </summary>
        [DataMember]
        public string Telephone { get; set; }

        /// <summary>
        /// Fax
        /// </summary>
        [DataMember]
        public string Fax { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Permissions
        /// </summary>
        [DataMember]
        [NotMapped]
        public ICollection<RolePermission> Permissions { get; set; }
    }

}
