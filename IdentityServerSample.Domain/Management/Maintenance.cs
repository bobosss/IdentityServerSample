using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Allweb.Core.Common.Contracts;

namespace Auditor.Business.Models
{
    /// <summary>
    /// Base class for all Auditor Maintenance Types
    /// </summary>
    /// <remarks>
    /// Proper Datacontract Namespace is located in AssemblyInfo.cs file. Namespace is equal to relative Client Side Model
    /// </remarks>
    [DataContract]
    public class Maintenance : EntityWithError
    {
        /// <summary>
        /// Maintenance default constructor
        /// </summary>
        public Maintenance()
        {

        }

        /// <summary>
        /// Maintenance special constructor
        /// </summary>
        protected Maintenance(string message, DateTime startTime, DateTime endTime)
        {
            
            Message = message;
            StartTime = startTime;
            EndTime = endTime;
            State = State.Added;
        }

        /// <summary>
        /// Static method Create to create a Maintenance entity using the given arguments
        /// </summary>
        public static Maintenance Create(string message, DateTime startTime, DateTime endTime)
        {
            return new Maintenance(message, startTime, endTime);
        }

        /// <summary>
        /// Primary key
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [DataMember]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Middle Name
        /// </summary>
        [DataMember]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Validation Errors
        /// </summary>
        [DataMember]
        [NotMapped]
        public Collection<MaintenanceValidation> ValidationErrors { get; set; }

        /// <summary>
        /// Validation Status
        /// </summary>
        [DataMember]
        [NotMapped]
        public int ValidationStatus { get; set; }

    }
}
