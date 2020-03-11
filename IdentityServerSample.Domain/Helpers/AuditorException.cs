using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Auditor.Business.Models
{
    /// <summary>
    /// Provides a custom Auditor Exception implementation
    /// </summary>
    /// <seealso cref="System.ApplicationException" />
    [DataContract]
    [NotMapped]
    public class AuditorException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuditorException"/> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorMessage">The error message.</param>
        public AuditorException(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditorException"/> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public AuditorException(string errorCode, string errorMessage, Exception innerException)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            InnerException = innerException;
        }

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>
        /// The error code.
        /// </value>
        [DataMember]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        [DataMember]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the inner exception.
        /// </summary>
        /// <value>
        /// The inner exception.
        /// </value>
        [DataMember]
        public Exception InnerException { get; set; }
    }
}
