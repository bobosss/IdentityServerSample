using System.Threading.Tasks;

namespace Allweb.Core.Common.Contracts
{
    /// <summary>
    /// Interface to enforce a method that returns an <see cref="IDataRepository">IDataRepository</see>
    /// </summary>
    /// <remarks>
    /// Abstract Factory Pattern
    /// </remarks>
    /// <remarks>
    /// This is where it comes handy the non Generic IDataRepository Interface.
    /// The Interface will be exposed through MEF
    /// </remarks>
    public interface IDataRepositoryFactory
    {
        T GetDataRepository<T>() where T : IDataRepository;
    }

    public interface IStatisticsDataRepositoryFactory
    {
        T GetDataRepository<T>() where T : IStatisticsDataRepository;
    }
    
    public interface IProposalsStatisticsDataRepositoryFactory
    {
        T GetDataRepository<T>() where T : IProposalsStatisticsDataRepository;
    }
}