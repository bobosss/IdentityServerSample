using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using Auditor.Security.Common.Models;
using System.Collections.ObjectModel;

namespace Auditor.Business.Models
{
    /// <summary>
    /// PersonStub
    /// </summary>
    [DataContract]
    [NotMapped]
    public class PersonStub
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PersonStub() { }

        /// <summary>
        /// Constructor
        /// </summary>
        public PersonStub(Person person)
        {
            Id = person.Id;
            UserId = person.UserId.GetValueOrDefault();
            FirstName = person.FirstName;
            LastName = person.LastName;
            MiddleName = person.MiddleName;
            Title = person.Title;
            Email = person.Email;
            IdentityCardNumber = person.IdentityCardNumber;
            Role = person.Role;
            Permissions = person.Permissions;
            Editable = person.Editable;
            ValidationErrors = person.ValidationErrors;
            ValidationStatus = person.ValidationStatus;
            Errors = person.Errors;
        }

        /// <summary>
        /// Primary key
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        [DataMember]
        public int UserId { get; set; }

        /// <summary>
        /// PIC
        /// </summary>
        [DataMember]
        public string UNIC { get; set; }

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
        /// Title
        /// </summary>
        /// <remarks>
        /// from lookup
        /// </remarks>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Identity Card Number
        /// </summary>
        [DataMember]
        public string IdentityCardNumber { get; set; }

        /// <summary>
        /// Comments
        /// </summary>
        /// <remarks>
        /// only in stub
        /// </remarks>
        [DataMember]
        public string Comments { get; set; }

        /// <summary>
        /// Etiology
        /// </summary>
        /// <remarks>
        /// only in stub
        /// </remarks>
        [DataMember]
        public string Etiology { get; set; }

        /// <summary>
        /// Roles
        /// </summary>
        /// <remarks>
        /// also in person, but as notMapped
        /// </remarks>
        [DataMember]
        public Collection<RoleObject> Roles { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        [DataMember]
        public Role Role { get; set; }

        /// <summary>
        /// Permissions
        /// </summary>
        [DataMember]
        public ICollection<RolePermission> Permissions { get; set; }

        /// <summary>
        /// Editable
        /// </summary>
        [DataMember]
        public bool Editable { get; set; }

        /// <summary>
        /// ChangeInfoRequest
        /// </summary>
        [DataMember]
        public bool? ChangeInfoRequest { get; set; }

        /// <summary>
        /// Validation Errors
        /// </summary>
        [DataMember]
        public ICollection<PersonValidation> ValidationErrors { get; set; }

        /// <summary>
        /// Validation Status
        /// </summary>
        [DataMember]
        public int ValidationStatus { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance has errors.
        /// </summary>
        [IgnoreDataMember]
        public bool HasErrors => Errors != null && Errors.Any();

        /// <summary>
        /// Errors
        /// </summary>
        [DataMember]
        public ICollection<AuditorException> Errors { get; set; }
    }

    /// <summary>
    /// RoleObject
    /// </summary>
    [DataContract]
    public class RoleObject
    {
        /// <summary>
        /// RoleName
        /// </summary>
        [DataMember]
        public string RoleName { get; set; }

        /// <summary>
        /// RoleCode
        /// </summary>
        [DataMember]
        public string RoleCode { get; set; }
    }
}
