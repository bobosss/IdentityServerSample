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
    [Export(typeof(ILookupRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LookupRepository : DataRepositoryBase<Lookup>, ILookupRepository
    {
        protected override Lookup AddEntity(ManagementDbContext entityContext, Lookup entity)
        {
            return entityContext.LookupSet.Add(entity);
        }

        protected override Lookup UpdateEntity(ManagementDbContext entityContext, Lookup entity)
        {
            return entityContext.LookupSet
                .Where(l => l.Id == entity.Id)
                .Select(l => l)
                .FirstOrDefault();
        }

        protected override Lookup GetEntity(ManagementDbContext entityContext, int id)
        {
            return entityContext.LookupSet
                .Where(l => l.Id == id)
                .Select(l => l)
                .FirstOrDefault();
        }

        protected override IEnumerable<Lookup> GetEntities(ManagementDbContext entityContext, 
            bool onlyFirstLevel)
        {
            return entityContext.LookupSet
                .Select(l => l);
        }

        protected override IEnumerable<Lookup> GetEntities(ManagementDbContext entityContext, Expression<Func<Lookup, bool>> where, 
            bool onlyFirstLevel)
        {
            return entityContext.LookupSet
                .Where(where)
                .Select(l => l);
        }
    }
}
