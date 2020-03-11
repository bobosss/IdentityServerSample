using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using Auditor.Business.Models;
using Auditor.Data.Contracts.Repository_Interfaces.Management;

namespace Auditor.Data.Management.Data_Repositories
{
    [Export(typeof(ICityRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CityRepository : DataRepositoryBase<City>, ICityRepository
    {
        protected override City AddEntity(ManagementDbContext entityContext, City entity)
        {
            return entityContext.CitySet.Add(entity);
        }

        protected override City UpdateEntity(ManagementDbContext entityContext, City entity)
        {
            return entityContext.CitySet
                .Where(r => r.Id == entity.Id)
                .Select(r => r)
                .FirstOrDefault();
        }

        protected override IEnumerable<City> GetEntities(ManagementDbContext entityContext, bool onlyFirstLevel)
        {
            return entityContext.CitySet.Select(r => r);
        }

        protected override City GetEntity(ManagementDbContext entityContext, int id)
        {
            return entityContext.CitySet
                .Where(r => r.Id == id)
                .Select(r => r)
                .FirstOrDefault();
        }

        protected override IEnumerable<City> GetEntities(ManagementDbContext entityContext, Expression<Func<City, bool>> where, bool onlyFirstLevel)
        {
            return entityContext.CitySet.Where(where).Select(p => p);
        }
    }
}
