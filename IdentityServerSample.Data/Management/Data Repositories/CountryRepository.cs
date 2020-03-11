using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using Auditor.Business.Models;
using Auditor.Data.Contracts.Repository_Interfaces.Management;

namespace Auditor.Data.Management.Data_Repositories
{
    [Export(typeof(ICountryRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CountryRepository : DataRepositoryBase<Country>, ICountryRepository
    {
        protected override Country AddEntity(ManagementDbContext entityContext, Country entity)
        {
            return entityContext.CountrySet.Add(entity);
        }

        protected override Country UpdateEntity(ManagementDbContext entityContext, Country entity)
        {
            return entityContext.CountrySet
                .Where(r => r.Id == entity.Id)
                .Select(r => r)
                .FirstOrDefault();
        }

        protected override IEnumerable<Country> GetEntities(ManagementDbContext entityContext, bool onlyFirstLevel)
        {
            return entityContext.CountrySet.Select(r => r);
        }

        protected override Country GetEntity(ManagementDbContext entityContext, int id)
        {
            return entityContext.CountrySet
                .Where(r => r.Id == id)
                .Select(r => r)
                .FirstOrDefault();
        }
        protected override IEnumerable<Country> GetEntities(ManagementDbContext entityContext, Expression<Func<Country, bool>> where, bool onlyFirstLevel)
        {
            return entityContext.CountrySet.Where(where).Select(p => p);
        }
    }
}
