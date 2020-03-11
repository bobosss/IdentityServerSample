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
    /// Base class for all Auditor Person Types
    /// </summary>
    /// <remarks>
    /// Proper Datacontract Namespace is located in AssemblyInfo.cs file.
    /// Namespace is equal to relative Client Side Model.
    /// </remarks>
    [DataContract]
    public class Person : EntityWithError, IPermissions
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [DataMember]
        public int Id { get; set; }
        /// <summary>
        /// Id of the AspNetUser in Security Database
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }
        /// <summary>
        /// Last Name
        /// </summary>
        [DataMember]
        public string LastName { get; set; }
        /// <summary>
        /// Middle Name
        /// </summary>
        [DataMember]
        public string MiddleName { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        [DataMember]
        public string Email { get; set; }
        /// <summary>
        /// Gender
        /// </summary>
        /// <remarks>
        /// from lookup
        /// </remarks>
        [DataMember]
        public string Gender { get; set; }
        /// <summary>
        /// Identity Card Number
        /// </summary>
        [DataMember]
        public string IdentityCardNumber { get; set; }

        /// <summary>
        /// Tax Code
        /// </summary>
        [DataMember]
        public string TaxCode { get; set; }

        /// <summary>
        /// Organization Title
        /// </summary>
        [DataMember]
        public string OrganizationTitle { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        /// <remarks>
        /// from lookup
        /// </remarks>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// JobTitle
        /// </summary>
        /// <remarks>
        /// from lookup
        /// </remarks>
        [DataMember]
        public string JobTitle { get; set; }

        /// <summary>
        /// Date of Birth
        /// </summary>
        [DataMember]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Nationality
        /// </summary>
        /// <remarks>
        /// from lookup
        /// </remarks>
        [DataMember]
        public string Nationality { get; set; }

        /// <summary>
        /// Person's Status (active or not)
        /// </summary>
        [DataMember]
        public bool IsActive { get; set; }

        /// <summary>
        /// Notes
        /// </summary>
        [DataMember]
        public string Notes { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [DataMember]
        public string Country { get; set; }

        /// <summary>
        /// Optimistic Concurrency Property
        /// </summary>
        [DataMember]
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// Phone Numbers
        /// </summary>
        [DataMember]
        public Collection<PersonPhoneNumber> PhoneNumbers { get; set; }
        /// <summary>
        /// Addresses
        /// </summary>
        [DataMember]
        public Collection<PersonAddress> Addresses { get; set; }
        /// <summary>
        /// Emails
        /// </summary>
        [DataMember]
        public Collection<PersonEmail> Emails { get; set; }

        /// <summary>
        /// Validation Errors
        /// </summary>
        [DataMember]
        [NotMapped]
        public Collection<PersonValidation> ValidationErrors { get; set; }

        /// <summary>
        /// Validation Status
        /// </summary>
        [DataMember]
        [NotMapped]
        public int ValidationStatus { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        [DataMember]
        [NotMapped]
        public Role Role { get; set; }

        /// <summary>
        /// Permissions
        /// </summary>
        [DataMember]
        [NotMapped]
        public ICollection<RolePermission> Permissions { get; set; }

        /// <summary>
        /// Editable (auxiliary property)
        /// </summary>
        [DataMember]
        [NotMapped]
        public bool Editable { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        [NotMapped]
        public string Username { get; set; }


        /// <summary>
        /// Roles
        /// </summary>
        [DataMember]
        [NotMapped]
        public Collection<RoleObject> Roles { get; set; }
    }

   
}
