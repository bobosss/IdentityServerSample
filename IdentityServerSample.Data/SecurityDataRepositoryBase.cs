using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Allweb.Core.Common.Contracts;
using Auditor.Security;
using System.Transactions;

namespace Auditor.Data
{
    // TODO: clarify best practice about the way we save in dbContext. See PersonManager for alternative
    /// <summary>
    /// Abstract Base class for data repositories. 
    /// Provides the basic coupling of <see cref="IDataRepository{T}">IDataRepository</see> behaviours with the actual implementation. 
    /// Also provides the public inteface methods for exporting for MEF.
    /// </summary>
    /// <see cref=".">Auditor.Architecture/Auditor.Data.Access/RepositoryPattern.classdiagram.</see>
    /// <typeparam name="T">entity</typeparam>
    /// <typeparam name="TU">DbContext</typeparam>
    public abstract class SecurityDataRepositoryBase<T, TU> : ISecurityDataRepository<T>
        where T : class, new()
        where TU : SecurityDbContext, new()
    {
        #region Abstract Methods

        /// <summary>
        /// Must be overridden in concrete classes to provide actual implementation for Adding Entity to database.
        /// </summary>
        /// <param name="entityContext">DbContext used to store the entity</param>
        /// <param name="entity">The entity to be added</param>
        /// <returns>The added entity</returns>
        protected abstract T AddEntity(TU entityContext, T entity);
        /// <summary>
        /// Must be overridden in concrete classes to provide actual implementation for Updating Entity to database.
        /// </summary>
        /// <param name="entityContext">DbContext used to store the entity</param>
        /// <param name="entity">The entity to be added</param>
        /// <returns>The updated entity</returns>
        protected abstract T UpdateEntity(TU entityContext, T entity);
        protected abstract IEnumerable<T> GetEntities(TU entityContext, string[] keys=null);
        protected abstract T GetEntity(TU entityContext, int id);
        protected abstract IEnumerable<T> GetEntities(TU entityContext, Expression<Func<T, bool>> where);

        #endregion

        #region IDataRepository Implementation

        /// <summary>
        /// Implement the <see cref="IDataRepository{T}">IDataRepository{T}.Add</see> pointing to abstract implementation of operation. 
        /// </summary>
        /// <param name="entity">Entity to Add</param>
        /// <returns>Added Entity</returns>
        public T Add(T entity)
        {
            using (TU entityContext = new TU())
            {
                T addedEntity = AddEntity(entityContext, entity);
                entityContext.SaveChanges();
                return addedEntity;
            }
        }

        /// <summary>
        /// Implement the <see cref="IDataRepository{T}">IDataRepository{T}.Remove</see> pointing to abstract implementation of operation. 
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            using (TU entityContext = new TU())
            {
                entityContext.Entry(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        /// <summary>
        /// Implement the <see cref="IDataRepository{T}">IDataRepository{T}.Remove</see> pointing to abstract implementation of operation. 
        /// </summary>
        /// <param name="id">Entity Id</param>
        public void Remove(int id)
        {
            using (TU entityContext = new TU())
            {
                T entity = GetEntity(entityContext, id);
                entityContext.Entry(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }
        
        /// <summary>
        /// Implement the <see cref="IDataRepository{T}">IDataRepository{T}.Update</see> pointing to abstract implementation of operation. 
        /// </summary>
        public T Update(T entity)
        {
            using (TU entityContext = new TU())
            {
                T returnedEntity = UpdateEntity(entityContext, entity);
                entityContext.SaveChanges();
                return returnedEntity;
            }
        }

        /// <summary>
        /// Implement the <see cref="IDataRepository{T}">IDataRepository{T}.Get</see> pointing to abstract implementation of operation. 
        /// </summary>
        public IEnumerable<T> Get()
        {
            using (TU entityContext = new TU())
            {
                // Always return list, otherwise an exception of disposed DBContext is thrown
                return GetEntities(entityContext).ToList();
            }
        }

        public T Get(int id)
        {
            using (TU entityContext = new TU())
            {
                return GetEntity(entityContext, id);
            }
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> @where)
        {
            using (TU entityContext = new TU())
            {
                // Always return list, otherwise an exception of disposed DBContext is thrown
                return GetEntities(entityContext, where).ToList();
            }
        }

        #endregion
    }
}
