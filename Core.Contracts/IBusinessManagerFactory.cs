namespace Allweb.Core.Common.Contracts
{
    public interface IBusinessManagerFactory
    {
        T GetBusinessManager<T>() where T : IBusinessManager;
    }
}
