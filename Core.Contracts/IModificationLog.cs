using System;

namespace Allweb.Core.Common.Contracts
{
    /// <summary>
    /// Interface that must be implemented in every model that needs to be storing information
    /// about created - updated datetimes/users
    /// </summary>
    public interface IModificationLog
    {
        /// <summary>
        /// Entity date modified
        /// </summary>
        DateTime DateModified { get; set; }

        /// <summary>
        /// Entity date created
        /// </summary>
        DateTime DateCreated { get; set; }

        /// <summary>
        /// Created By UserId
        /// </summary>
        int CreatedBy { get; set; }

        /// <summary>
        /// Modified By UserId
        /// </summary>
        int ModifiedBy { get; set; }
    }
}
