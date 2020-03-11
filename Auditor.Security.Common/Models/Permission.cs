
using System.ComponentModel.DataAnnotations;

namespace Auditor.Security.Common.Models
{
    /// <summary>
    /// Permission entity
    /// </summary>
    public class Permission
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the object name.
        /// </summary>
        [Required]
        public string ObjectName { get; set; }
    }
}
