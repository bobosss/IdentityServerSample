using System.ComponentModel.Composition;
using Allweb.Core.Common.Contracts;
using Allweb.Core.Common.Core;

namespace Auditor.Data
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Abstract Factory Pattern</remarks>
    /// <remarks>This is also exported to be used in MEF</remarks>
    [Export(typeof(IDataRepositoryFactory))]
    // Not Shared Creation Policy so as not to create singleton (MEF) - Read
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        #region IDataRepositoryFactory Members

        /// <summary>
        /// Get the DataRepository we need through MEF
        /// </summary>
        /// <typeparam name="T">IDataRepositoryType</typeparam>
        /// <returns>IDataRepository</returns>
        T IDataRepositoryFactory.GetDataRepository<T>()
        {
            // GetExportedValue resolves the concrete class stored in CompositionContainer
            return ObjectBase.Container.GetExportedValue<T>();
        }

        #endregion
    }

}
    

    

