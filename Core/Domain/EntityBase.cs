using System;
using System.Runtime.Serialization;
using Allweb.Core.Common.Contracts;

namespace Allweb.Core.Common.Core
{
    [DataContract]
    public abstract class EntityBase : IExtensibleDataObject, IModificationLog, IEntityState
    {
        public ExtensionDataObject ExtensionData { get; set; }

        /// <summary>
        /// Business Date Created
        /// </summary>
        [DataMember]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Business Date Modified
        /// </summary>
        [DataMember]
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Business CreatedBy UserId
        /// </summary>
        [DataMember]
        public int CreatedBy { get; set; }

        /// <summary>
        /// Business ModifiedBy UserId
        /// </summary>
        [DataMember]
        public int ModifiedBy { get; set; }

        /// <summary>
        /// Business State
        /// </summary>
        [DataMember]
        public State State { get; set; }
    }
}
