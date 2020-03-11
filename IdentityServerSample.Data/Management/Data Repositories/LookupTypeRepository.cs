using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Auditor.Business.Models;
using Auditor.Data.Contracts.Repository_Interfaces.Management;

namespace Auditor.Data.Management.Data_Repositories
{
    [Export(typeof(ILookupTypeRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LookupTypeRepository : DataRepositoryBase<LookupType>, ILookupTypeRepository
    {
        protected override LookupType AddEntity(ManagementDbContext entityContext, LookupType entity)
        {
            return entityContext.LookupTypeSet.Add(entity);
        }

        protected override LookupType UpdateEntity(ManagementDbContext entityContext, LookupType entity)
        {
            return entityContext.LookupTypeSet
                .Include(l => l.Lookups.Select(x => x.Children))
                .Where(l => l.Id == entity.Id)
                .Select(l => l)
                .FirstOrDefault();
        }

        protected override LookupType GetEntity(ManagementDbContext entityContext, int id)
        {
            return entityContext.LookupTypeSet
                .Include(l => l.Lookups.Select(x => x.Children))
                .Include(l => l.Lookups.Select(x => x.Parent))
                .Where(l => l.Id == id)
                .Select(l => l)
                .FirstOrDefault();
        }

        protected override IEnumerable<LookupType> GetEntities(ManagementDbContext entityContext, bool onlyFirstLevel)
        {
            return entityContext.LookupTypeSet
                .Include(l => l.Lookups.Select(x => x.Children))
                .Select(l => l);
        }

        protected override IEnumerable<LookupType> GetEntities(ManagementDbContext entityContext, Expression<Func<LookupType, bool>> where, bool onlyFirstLevel)
        {
            return entityContext.LookupTypeSet
                .Include(l => l.Lookups.Select(x => x.Children))
                .Where(where)
                .Select(l => l);
        }
    }
}
