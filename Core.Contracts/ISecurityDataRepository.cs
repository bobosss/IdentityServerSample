using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Allweb.Core.Common.Contracts
{

    /// <summary>
    /// IDataRepository of T. Will define all basic CRUD set of operations.
    /// </summary>
    /// <remarks>
    /// <see cref="https://msdn.microsoft.com/en-us/library/d5x73970.aspx">See MSDN for, new () type argument constraint</see> 
    /// </remarks>
    public interface ISecurityDataRepository<T> : IDataRepository where T : class, new()
    {
        T Add(T entity);
        void Remove(T entity);
        void Remove(int id);
        T Update(T entity);
        IEnumerable<T> Get();
        T Get(int id);
        IEnumerable<T> Get(Expression<Func<T, bool>> where);
    }
}
