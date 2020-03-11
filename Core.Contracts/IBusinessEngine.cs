using System.Collections.Generic;

namespace Allweb.Core.Common.Contracts
{

    /// <summary>
    /// Base Interfase for the Abstract Factory Pattern
    /// </summary>
    public interface IBusinessEngine
    {
    }

    /// <summary>
    /// IDataRepository of T. Will define all basic CRUD set of operations.
    /// </summary>
    /// <remarks>
    /// <see cref="https://msdn.microsoft.com/en-us/library/d5x73970.aspx">See MSDN for, new () type argument constraint</see> 
    /// </remarks>
    public interface IBusinessEngine<T> : IBusinessEngine where T : class, new()
    {
        T Add(T entity);
        void Remove(T entity);
        void Remove(int id);
        T Update(T entity);
        IEnumerable<T> Get();
        T Get(int id);
    }
}
