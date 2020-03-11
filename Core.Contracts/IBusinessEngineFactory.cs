namespace Allweb.Core.Common.Contracts
{
    /// <summary>
    /// Interface to enforce a method that returns an <see cref="IBusinessEngine">IBusinessEngine</see>
    /// </summary>
    /// <remarks>
    /// Abstract Factory Pattern
    /// </remarks>
    /// <remarks>
    /// The Interface will be exposed through MEF
    /// </remarks>
    public interface IBusinessEngineFactory
    {
        T GetBusinessEngine<T>() where T : IBusinessEngine;
    }
}