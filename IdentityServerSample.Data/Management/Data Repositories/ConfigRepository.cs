using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using Auditor.Business.Models;
using Auditor.Data.Contracts.Repository_Interfaces.Management;

namespace Auditor.Data.Management.Data_Repositories
{
    [Export(typeof(IConfigRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ConfigRepository : DataRepositoryBase<Config>, IConfigRepository
    {
        protected override Config AddEntity(ManagementDbContext entityContext, Config entity)
        {
            return entityContext.ConfigSet.Add(entity);
        }

        protected override Config UpdateEntity(ManagementDbContext entityContext, Config entity)
        {
            return entityContext.ConfigSet
                .Where(r => r.Id == entity.Id)
                .Select(r => r)
                .FirstOrDefault();
        }

        protected override IEnumerable<Config> GetEntities(ManagementDbContext entityContext, bool onlyFirstLevel)
        {
            return entityContext.ConfigSet.Select(r => r);
        }

        protected override Config GetEntity(ManagementDbContext entityContext, int id)
        {
            return entityContext.ConfigSet
                .Where(r => r.Id == id)
                .Select(r => r)
                .FirstOrDefault();
        }
        protected override IEnumerable<Config> GetEntities(ManagementDbContext entityContext, Expression<Func<Config, bool>> where, bool onlyFirstLevel)
        {
            return entityContext.ConfigSet.Where(where).Select(p => p);
        }
    }
}
