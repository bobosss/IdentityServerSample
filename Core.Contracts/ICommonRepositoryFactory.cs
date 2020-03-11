using System.Threading.Tasks;

namespace Allweb.Core.Common.Contracts
{
    /// <summary>
    /// Interface to enforce a method that returns an <see cref="ICommonRepository">ICommonRepository</see>
    /// </summary>
    /// <remarks>
    /// Abstract Factory Pattern
    /// </remarks>
    public interface ICommonRepositoryFactory
    {
        T GetCommonRepository<T>() where T : ICommonRepository;
    }
}