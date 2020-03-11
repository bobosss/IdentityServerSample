using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Allweb.Core.Common.Contracts
{
    /// <summary>
    /// Base Interfase for the Repository Pattern
    /// </summary>
    public interface IDataRepository
    {
    }

    /// <summary>
    /// IDataRepository of T. Will define all basic CRUD set of operations.
    /// </summary>
    /// <remarks>
    /// <see cref="https://msdn.microsoft.com/en-us/library/d5x73970.aspx">
    /// See MSDN for, new () type argument constraint
    /// </see> 
    /// </remarks>
    public interface IDataRepository<T> : IDataRepository where T : class, new()
    {
        T Add(T entity, int userId, string callId = null);
        void Remove(T entity, int userId, string callId = null);
        void Remove(int id, int userId, string callId = null);
        T Update(T entity, int userId, string callId = null);
        IEnumerable<T> Get(int userId, string callId = null, bool onlyFirstLevel = true);
        T Get(int id, int userId, string callId = null);
        //IEnumerable<T> Get(string[] keyStrings, int userId, string callId = null);
        IEnumerable<T> Get(Expression<Func<T, bool>> where, string callId = null, bool onlyFirstLevel = false);
    }

    public interface IVersionedDataRepository<T> : IDataRepository<T> where T : class, new()
    {
        int GetMaxVersion(int id);
    }

    public interface IPersonDataRepository<T> : IDataRepository<T> where T : class, new()
    {
        IEnumerable<T> GetPersonsWithoutResearcher();
        IEnumerable<T> GetAllResearcherForStatistics();
    }

    public interface IIdPoolRepository<T> : IDataRepository<T> where T : class, new()
    {
        T Get(string classname);
        int GetNextNum(string sec);
        int ApplyNextNum(string sec);
    }



    public interface IStatisticsDataRepository
    {
    }
    public interface IStatisticsDataRepository<T> : IStatisticsDataRepository where T : class, new()
    {
        IEnumerable<T> GetLRsWithNotSubmittedOrganizations();
        IEnumerable<T> GetLRsWithSubmittedOrganizations();
        IEnumerable<T> OrganizationsWithNotSubmittedLegalInfo();
        IEnumerable<T> LRsWithSubmittedOrganizationsAndSubmittedLegalInfo();
        IEnumerable<T> RPFNewsletter();
        IEnumerable<T> NewsAlert();
        IEnumerable<T> CallAlert();
        IEnumerable<T> EventAlert();
        IEnumerable<T> RTDPartnerSearches();
        IEnumerable<T> TechnologyOffers();
        IEnumerable<T> TechnologyRequests();
        IEnumerable<T> OrganizationsType();
    }

    public interface IProposalsStatisticsDataRepository
    {
    }
    public interface IProposalsStatisticsDataRepository<T> : IProposalsStatisticsDataRepository where T : class, new()
    {
        IEnumerable<T> ProposalsConsortiumStatistic(string callId);

        IEnumerable<T> CallStatistic(string callId);
    }
    public interface IConstructorDataRepository<T> : IDataRepository<T> where T : class, new()
    {

    }
}
