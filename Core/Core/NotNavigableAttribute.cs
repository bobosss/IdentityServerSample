using System;

namespace Allweb.Core.Common.Core
{
    /// <summary>
    /// Attribute used in <see cref="ObjectBase">ObjectBase</see> 
    /// to prevent recursive property walking in Object Graph.
    /// <seealso cref="ObjectBase.WalkObjectGraph">ObjectBase.WalkObjectGraph</seealso>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NotNavigableAttribute : Attribute
    {
    }
}
