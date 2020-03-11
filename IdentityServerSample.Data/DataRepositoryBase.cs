using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Allweb.Core.Common.Contracts;
using Allweb.Core.Common.Data;
using Allweb.Core.Common.Exceptions;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.Caching;

namespace Auditor.Data
{
    /// <summary>
    /// Abstract Base class for data repositories.
    /// Provides the basic coupling of <see cref="IDataRepository{T}">IDataRepository</see>
    /// behaviors with the actual implementation.
    /// Also provides the public inteface methods for exporting for MEF.
    /// </summary>
    /// <see>Auditor.Architecture/Auditor.Data.Access/RepositoryPattern.classdiagram</see>
    /// <typeparam name="T">entity</typeparam>
    /// <typeparam name="TU">DbContext</typeparam>
    public abstract class DataRepositoryBase<T, TU> : IDataRepository<T>
        where T : class, new()
        where TU : AuditorDbContextBase
        //was: where TU: AuditorDbContextBase, new()
    {
        #region Abstract Methods

        /// <summary>
        /// Must be overridden in concrete classes to provide actual implementation for Adding Entity to database.
        /// </summary>
        /// <param name="entityContext">DbContext used to store the entity</param>
        /// <param name="entity">The entity to be added</param>
        /// <returns>The added entity</returns>
        protected abstract T AddEntity(TU entityContext, T entity);
        
        protected abstract T UpdateEntity(TU entityContext, T entity);

        protected abstract IEnumerable<T> GetEntities(TU entityContext, bool onlyFirstLevel = true);
        
        protected abstract T GetEntity(TU entityContext, int id);

        protected abstract IEnumerable<T> GetEntities(TU entityContext, Expression<Func<T, bool>> where, bool onlyFirstLevel = false);

        #endregion

        #region IDataRepository Implementation

        // https://rogeralsing.com/2008/02/28/linq-expressions-creating-objects/
        // https://vagifabilov.wordpress.com/2010/04/02/dont-use-activator-createinstance-or-constructorinfo-invoke-use-compiled-lambda-expressions/
        // use compiled lambda instead of Activator.CreateInstance or ConstructorInfo.Invoke => great performance gain!
        // Activator.CreateInstance was needed instead of using (TU entityContext = new TU())
        // because we needed a parameterized constructor
        delegate Ta ObjectActivator<Ta>(params object[] args);
        private static ObjectActivator<Ta> GetActivator<Ta>(ConstructorInfo ctor)
        {
            Type type = ctor.DeclaringType;
            ParameterInfo[] paramsInfo = ctor.GetParameters();

            //create a single param of type object[]
            ParameterExpression param =
                Expression.Parameter(typeof(object[]), "args");

            Expression[] argsExp =
                new Expression[paramsInfo.Length];

            //pick each arg from the params array 
            //and create a typed expression of them
            for (int i = 0; i < paramsInfo.Length; i++)
            {
                Expression index = Expression.Constant(i);
                Type paramType = paramsInfo[i].ParameterType;

                Expression paramAccessorExp =
                    Expression.ArrayIndex(param, index);

                Expression paramCastExp =
                    Expression.Convert(paramAccessorExp, paramType);

                argsExp[i] = paramCastExp;
            }

            //make a NewExpression that calls the
            //ctor with the args we just created
            NewExpression newExp = Expression.New(ctor, argsExp);

            //create a lambda with the New
            //Expression as body and our param object[] as arg
            LambdaExpression lambda =
                Expression.Lambda(typeof(ObjectActivator<Ta>), newExp, param);

            //compile it
            ObjectActivator<Ta> compiled = (ObjectActivator<Ta>)lambda.Compile();
            return compiled;
        }
        
        public T Add(T entity, int userId, string callId)
        {
            //was: using (TU entityContext = new TU()) { ... }
            TU entityContext;
            ConstructorInfo ctor;
            Type[] types = new Type[1];
            types[0] = typeof(string);
            if (callId == null)
                ctor = typeof(TU).GetConstructors().First();
            else
                ctor = typeof(TU).GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, types, null);

            ObjectActivator<TU> createdActivator = GetActivator<TU>(ctor);
            if (callId == null)
                //entityContext = Activator.CreateInstance(typeof(TU), new object[] { }) as TU;
                entityContext = createdActivator();
            else
                //entityContext = Activator.CreateInstance(typeof(TU), new object[] { callId }) as TU;
                entityContext = createdActivator(callId);
            
            using (var dbContextTransaction = entityContext.Database.BeginTransaction())
            {
                T addedEntity = AddEntity(entityContext, entity);
                foreach (var dbEntityEntry in entityContext.ChangeTracker.Entries<IEntityState>())
                {
                    IEntityState entityStateInfo = dbEntityEntry.Entity;
                    dbEntityEntry.State = EntityStateConvert.ConvertState(entityStateInfo.State);
                }
                entityContext.UserId = userId;
                try
                {
                    entityContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    dbContextTransaction.Rollback();
                    throw new UpdateConcurrencyException($"The record you attempted to edit was modified " +
                        "by another user after you got the original values");
                }
                // TODO: add try catch here and to the other methods below
                // and handle exception in Managers and test properly
                // dbContextTransaction.Commit();

                // addition to include needed entities after add
                if (addedEntity != null)
                    return UpdateEntity(entityContext, addedEntity);
                return addedEntity;
            }
        }
        
        public void Remove(T entity, int userId, string callId)
        {
            TU entityContext;
            ConstructorInfo ctor;
            Type[] types = new Type[1];
            types[0] = typeof(string);
            if (callId == null)
                ctor = typeof(TU).GetConstructors().First();
            else
                ctor = typeof(TU).GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, types, null);

            ObjectActivator<TU> createdActivator = GetActivator<TU>(ctor);
            if (callId == null)
                entityContext = createdActivator();
            else
                entityContext = createdActivator(callId);

            using (var dbContextTransaction = entityContext.Database.BeginTransaction())
            {
                entityContext.Entry(entity).State = EntityState.Deleted;
                entityContext.UserId = userId;
                entityContext.SaveChanges();
                dbContextTransaction.Commit();
            }
        }
        
        public void Remove(int id, int userId, string callId)
        {
            TU entityContext;
            ConstructorInfo ctor;
            Type[] types = new Type[1];
            types[0] = typeof(string);
            if (callId == null)
                ctor = typeof(TU).GetConstructors().First();
            else
                ctor = typeof(TU).GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, types, null);

            ObjectActivator<TU> createdActivator = GetActivator<TU>(ctor);
            if (callId == null)
                entityContext = createdActivator();
            else
                entityContext = createdActivator(callId);

            using (var dbContextTransaction = entityContext.Database.BeginTransaction())
            {
                T entity = GetEntity(entityContext, id);
                entityContext.Entry(entity).State = EntityState.Deleted;
                entityContext.UserId = userId;
                entityContext.SaveChanges();
                dbContextTransaction.Commit();
            }
        }
        
        public T Update(T entity, int userId, string callId)
        {
            TU entityContext;
            ConstructorInfo ctor;
            Type[] types = new Type[1];
            types[0] = typeof(string);
            if (callId == null)
                ctor = typeof(TU).GetConstructors().First();
            else
                ctor = typeof(TU).GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, types, null);

            ObjectActivator<TU> createdActivator = GetActivator<TU>(ctor);
            if (callId == null)
                entityContext = createdActivator();
            else
                entityContext = createdActivator(callId);
            
            using (var dbContextTransaction = entityContext.Database.BeginTransaction())
            {
                entityContext.Set<T>().Add(entity);
                
                foreach (var dbEntityEntry in entityContext.ChangeTracker.Entries<IEntityState>())
                {
                    IEntityState entityStateInfo = dbEntityEntry.Entity;
                    dbEntityEntry.State = EntityStateConvert.ConvertState(entityStateInfo.State);
                }
                entityContext.UserId = userId;
                try
                {
                    entityContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    dbContextTransaction.Rollback();
                    throw new UpdateConcurrencyException($"The record you attempted to edit was modified " +
                        "by another user after you got the original values");
                }
                
                T entityToRet = UpdateEntity(entityContext, entity);
                if (entityToRet == null)
                    // vital fix! After proposal deletion UpdateEntity returns null,
                    // so in such cases just return the entity
                    return entity;
                return entityToRet;
            }
        }
        
        public IEnumerable<T> Get(int userId, string callId, bool onlyFirstLevel)
        {
            TU entityContext;
            ConstructorInfo ctor;
            Type[] types = new Type[1];
            types[0] = typeof(string);
            if (callId == null)
                ctor = typeof(TU).GetConstructors().First();
            else
                ctor = typeof(TU).GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, types, null);

            ObjectActivator<TU> createdActivator = GetActivator<TU>(ctor);
            if (callId == null)
                entityContext = createdActivator();
            else
                entityContext = createdActivator(callId);
            
            // Always return list, otherwise an exception of disposed DBContext is thrown
            var entities = GetEntities(entityContext, onlyFirstLevel).ToList();
            return entities;
        }
        
        public T Get(int id, int userId, string callId)
        {
            TU entityContext;
            ConstructorInfo ctor;
            Type[] types = new Type[1];
            types[0] = typeof(string);
            if (callId == null)
                ctor = typeof(TU).GetConstructors().First();
            else
                ctor = typeof(TU).GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, types, null);

            ObjectActivator<TU> createdActivator = GetActivator<TU>(ctor);
            if (callId == null)
                entityContext = createdActivator();
            else
                entityContext = createdActivator(callId);
            
            var entity = GetEntity(entityContext, id);

            return entity;
        }
        
        public IEnumerable<T> Get(Expression<Func<T, bool>> where, string callId, bool onlyFirstLevel)
        {
            

            TU entityContext;
            ConstructorInfo ctor;
            Type[] types = new Type[1];
            types[0] = typeof(string);
            if (callId == null)
                ctor = typeof(TU).GetConstructors().First();
            else
                ctor = typeof(TU).GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, types, null);

            ObjectActivator<TU> createdActivator = GetActivator<TU>(ctor);
            if (callId == null)
                entityContext = createdActivator();
            else
                entityContext = createdActivator(callId);
            
            // Always return list, otherwise an exception of disposed DBContext is thrown
            var entities = GetEntities(entityContext, where, onlyFirstLevel).ToList();
            return entities;
        }

        #endregion
    }
    
    public abstract class VersionedDataRepositoryBase<T, TU> : DataRepositoryBase<T, TU>, IVersionedDataRepository<T>
        where T : class, new()
        where TU : AuditorDbContextBase, new()
    {
        #region Abstract Methods

        protected abstract int GetMaxVersion(TU entityContext, int id);

        #endregion

        #region IVersionedDataRepository Implementation

        public int GetMaxVersion(int id)
        {
            using (TU entityContext = new TU())
            {
                return (GetMaxVersion(entityContext, id)); 
            }
        }

        #endregion
    }
    
    
    public abstract class PersonDataRepositoryBase<T, TU> : DataRepositoryBase<T, TU>, IPersonDataRepository<T>
        where T : class, new()
        where TU : AuditorDbContextBase, new()
    {
        #region Abstract Methods

        protected abstract IEnumerable<T> GetPersonsWithoutResearcher(TU entityContext);
        protected abstract IEnumerable<T> GetAllResearcherForStatistics(TU entityContext);

        #endregion

        #region IPersonDataRepository Implementation

        public IEnumerable<T> GetPersonsWithoutResearcher()
        {
            using (TU entityContext = new TU())
            {
                return (GetPersonsWithoutResearcher(entityContext));
            }
        }
        public IEnumerable<T> GetAllResearcherForStatistics()
        {
            using (TU entityContext = new TU())
            {
                return (GetAllResearcherForStatistics(entityContext));
            }
        }
        #endregion
    }
    
    public abstract class ProposalsStatisticsDataRepositoryBase<T, TU> : IProposalsStatisticsDataRepository<T>
        where T : class, new()
        where TU : AuditorDbContextBase, new()
    {
        #region Abstract Methods
        
        protected abstract IEnumerable<T> ProposalsConsortiumStatistic(TU entityContext);

        protected abstract IEnumerable<T> CallStatistic(TU entityContext);

        protected abstract IEnumerable<T> CallStatisticStaging(TU entityContext);

        #endregion

        #region IProposalsStatisticsDataRepository Implementation

        delegate Ta ObjectActivator<Ta>(params object[] args);
        private static ObjectActivator<Ta> GetActivator<Ta>(ConstructorInfo ctor)
        {
            Type type = ctor.DeclaringType;
            ParameterInfo[] paramsInfo = ctor.GetParameters();

            //create a single param of type object[]
            ParameterExpression param =
                Expression.Parameter(typeof(object[]), "args");

            Expression[] argsExp =
                new Expression[paramsInfo.Length];

            //pick each arg from the params array 
            //and create a typed expression of them
            for (int i = 0; i < paramsInfo.Length; i++)
            {
                Expression index = Expression.Constant(i);
                Type paramType = paramsInfo[i].ParameterType;

                Expression paramAccessorExp =
                    Expression.ArrayIndex(param, index);

                Expression paramCastExp =
                    Expression.Convert(paramAccessorExp, paramType);

                argsExp[i] = paramCastExp;
            }

            //make a NewExpression that calls the
            //ctor with the args we just created
            NewExpression newExp = Expression.New(ctor, argsExp);

            //create a lambda with the New
            //Expression as body and our param object[] as arg
            LambdaExpression lambda =
                Expression.Lambda(typeof(ObjectActivator<Ta>), newExp, param);

            //compile it
            ObjectActivator<Ta> compiled = (ObjectActivator<Ta>)lambda.Compile();
            return compiled;
        }

        public IEnumerable<T> ProposalsConsortiumStatistic(string callId)
        {
            TU entityContext;
            ConstructorInfo ctor;
            Type[] types = new Type[1];
            types[0] = typeof(string);

            ctor = typeof(TU).GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, types, null);

            ObjectActivator<TU> createdActivator = GetActivator<TU>(ctor);

            entityContext = createdActivator(callId);

                return (ProposalsConsortiumStatistic(entityContext));
        
        }

        public IEnumerable<T> CallStatistic(string callId)
        {
            TU entityContext;
            ConstructorInfo ctor;
            Type[] types = new Type[1];
            types[0] = typeof(string);

            ctor = typeof(TU).GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, types, null);

            ObjectActivator<TU> createdActivator = GetActivator<TU>(ctor);

            entityContext = createdActivator(callId);

            if (entityContext.Database.Connection.Database.Contains("AuditorBPM"))
                return (CallStatistic(entityContext));
            else
                return (CallStatisticStaging(entityContext));

        }

        #endregion
    }

    public abstract class StatisticsDataRepositoryBase<T, TU> : IStatisticsDataRepository<T>
        where T : class, new()
        where TU : AuditorDbContextBase, new()
    {
        #region Abstract Methods

        protected abstract IEnumerable<T> GetLRsWithNotSubmittedOrganizations(TU entityContext);
        protected abstract IEnumerable<T> GetLRsWithSubmittedOrganizations(TU entityContext);
        protected abstract IEnumerable<T> OrganizationsWithNotSubmittedLegalInfo(TU entityContext);
        protected abstract IEnumerable<T> LRsWithSubmittedOrganizationsAndSubmittedLegalInfo(TU entityContext);
        protected abstract IEnumerable<T> RPFNewsletter(TU entityContext);
        protected abstract IEnumerable<T> NewsAlert(TU entityContext);
        protected abstract IEnumerable<T> CallAlert(TU entityContext);
        protected abstract IEnumerable<T> EventAlert(TU entityContext);
        protected abstract IEnumerable<T> RTDPartnerSearches(TU entityContext);
        protected abstract IEnumerable<T> TechnologyOffers(TU entityContext);
        protected abstract IEnumerable<T> TechnologyRequests(TU entityContext);
        protected abstract IEnumerable<T> OrganizationsType(TU entityContext);

        #endregion

        #region IStatisticsDataRepository Implementation

        public IEnumerable<T> GetLRsWithNotSubmittedOrganizations()
        {
            using (TU entityContext = new TU())
            {
                return (GetLRsWithNotSubmittedOrganizations(entityContext));
            }
        }
        public IEnumerable<T> GetLRsWithSubmittedOrganizations()
        {
            using (TU entityContext = new TU())
            {
                return (GetLRsWithSubmittedOrganizations(entityContext));
            }
        }
        public IEnumerable<T> OrganizationsWithNotSubmittedLegalInfo()
        {
            using (TU entityContext = new TU())
            {
                return (OrganizationsWithNotSubmittedLegalInfo(entityContext));
            }
        }
        public IEnumerable<T> LRsWithSubmittedOrganizationsAndSubmittedLegalInfo()
        {
            using (TU entityContext = new TU())
            {
                return (LRsWithSubmittedOrganizationsAndSubmittedLegalInfo(entityContext));
            }
        }
        public IEnumerable<T> RPFNewsletter()
        {
            using (TU entityContext = new TU())
            {
                return (RPFNewsletter(entityContext));
            }
        }
        public IEnumerable<T> NewsAlert()
        {
            using (TU entityContext = new TU())
            {
                return (NewsAlert(entityContext));
            }
        }
        public IEnumerable<T> CallAlert()
        {
            using (TU entityContext = new TU())
            {
                return (CallAlert(entityContext));
            }
        }
        public IEnumerable<T> EventAlert()
        {
            using (TU entityContext = new TU())
            {
                return (EventAlert(entityContext));
            }
        }
        public IEnumerable<T> RTDPartnerSearches()
        {
            using (TU entityContext = new TU())
            {
                return (RTDPartnerSearches(entityContext));
            }
        }
        public IEnumerable<T> TechnologyOffers()
        {
            using (TU entityContext = new TU())
            {
                return (TechnologyOffers(entityContext));
            }
        }
        public IEnumerable<T> TechnologyRequests()
        {
            using (TU entityContext = new TU())
            {
                return (TechnologyRequests(entityContext));
            }
        }
        public IEnumerable<T> OrganizationsType()
        {
            using (TU entityContext = new TU())
            {
                return (OrganizationsType(entityContext));
            }
        }

        #endregion
    }
    
    public abstract class IdPoolRepositoryBase<T, TU> : DataRepositoryBase<T, TU>, IIdPoolRepository<T>
        where T : class, new()
        where TU : AuditorDbContextBase, new()
    {
        #region Abstract Methods

        protected abstract T GetEntity(TU entityContext, string classname);
        protected abstract int GetNextSequenceNumber(TU entityContext, string sec);
        protected abstract int ApplyNextSequenceNumber(TU entityContext, string sec);
        
        
        #endregion

        #region IdPoolRepositoryBase Implementation

        public T Get(string classname)
        {
            using (TU entityContext = new TU())
            {
                return (GetEntity(entityContext, classname));
            }
        }

        public int GetNextNum(string sec)
        {
            using (TU entityContext = new TU())
            {
                return (GetNextSequenceNumber(entityContext, sec));
            }
        }


        public int ApplyNextNum(string sec)
        {
            using (TU entityContext = new TU())
            {
                return (ApplyNextSequenceNumber(entityContext, sec));
            }
        }

        #endregion
    }
}
