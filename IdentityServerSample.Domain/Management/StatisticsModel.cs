using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Auditor.Security.Common.Models;

namespace Auditor.Business.Models
{
    /// <summary>
    /// StatisticsModel
    /// </summary>
    [DataContract]
    [NotMapped]
    public class StatisticsModel : EntityWithError, IPermissions
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [DataMember]
        public int Id { get; set; }
        
        /// <summary>
        /// Person UNIC
        /// </summary>
        [DataMember]
        public string IRID { get; set; }

        /// <summary>
        /// OrganizationName
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// UserId
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
        /// Middle Name
        /// </summary>
        [DataMember]
        public string Title { get; set; }
        
        /// <summary>
        /// E-mail
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Legal Representative Id (foreign key)
        /// </summary>
        [DataMember]
        public int LegalRepresentativeId { get; set; }

        /// <summary>
        /// YoungResearcherName
        /// </summary>
        [DataMember]
        public string YoungResearcherName { get; set; }

        /// <summary>
        /// OrganizationId
        /// </summary>
        [DataMember]
        public int OrganizationId { get; set; }

        /// <summary>
        /// OrganizationUNIC 
        /// </summary>
        [DataMember]
        public string UNIC { get; set; }

        /// <summary>
        /// OrganizationCategory 
        /// </summary>
        [DataMember]
        public string OrganizationCategory { get; set; }

        /// <summary>
        /// ParentTitle 
        /// </summary>
        [DataMember]
        public string ParentTitle { get; set; }

        /// <summary>
        /// ChildTitle 
        /// </summary>
        [DataMember]
        public string ChildTitle { get; set; }
        
        /// <summary>
        /// LegalInfoVersionPk 
        /// </summary>
        [DataMember]
        public int LegalInfoVersionPk { get; set; }

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
        /// Role
        /// </summary>
        [DataMember]
        public Role Role { get; set; }

        /// <summary>
        /// Permissions
        /// </summary>
        [DataMember]
        public ICollection<RolePermission> Permissions { get; set; }
    }
}
