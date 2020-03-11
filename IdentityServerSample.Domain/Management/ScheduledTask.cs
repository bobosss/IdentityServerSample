using Auditor.Security.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Auditor.Business.Models
{
    /// <summary>
    /// ScheduledTask
    /// </summary>
    [DataContract]
    public class ScheduledTask : EntityWithError, IPermissions
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Action
        /// </summary>
        [DataMember]
        public string Action { get; set; }

        /// <summary>
        /// Response
        /// </summary>
        [DataMember]
        public string Response { get; set; }

        /// <summary>
        /// ExecutedTime
        /// </summary>
        [DataMember]
        public DateTime? ExecutedTime { get; set; }

        /// <summary>
        /// LastExecutionTry
        /// </summary>
        [DataMember]
        public DateTime? LastExecutionTry { get; set; }

        /// <summary>
        /// Interval
        /// </summary>
        /// <remarks>
        /// In Minutes
        /// </remarks>
        [DataMember]
        public int? Interval { get; set; }

        /// <summary>
        /// ExecutionTime
        /// </summary>
        [DataMember]
        public DateTime? ExecutionTime { get; set; }

        /// <summary>
        /// ActionConfigOptions
        /// </summary>
        /// <remarks>
        /// format option like days:12,sendmail:1
        /// </remarks>
        [DataMember]
        public string ActionConfigOptions { get; set; }
        
        /// <summary>
        /// Permissions
        /// </summary>
        [DataMember]
        [NotMapped]
        public ICollection<RolePermission> Permissions { get; set; }
    }
}
