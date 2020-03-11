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
    // Read Attributed Programming Model Overview (MEF)
    // https://msdn.microsoft.com/en-us/library/ee155691%28v=vs.110%29.aspx 
    // ExportAttribute. Used in MEF DI ?? - Read on that
    [Export(typeof(IConstructorRepository))]
    // Not Shared Creation Policy so as not to create singleton (MEF) - Read on that too
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ConstructorRepository : DataRepositoryBase<Constructor>, IConstructorRepository
    {
        protected override Constructor AddEntity(ManagementDbContext entityContext, Constructor entity)
        {
            return entityContext.ConstructorSet.Add(entity);
        }

        protected override Constructor UpdateEntity(ManagementDbContext entityContext, Constructor entity)
        {
            return entityContext.ConstructorSet
                .Where(p => p.Id == entity.Id)
                .Select(p => p)
                .FirstOrDefault();
        }

        protected override IEnumerable<Constructor> GetEntities(ManagementDbContext entityContext, bool onlyFirstLevel)
        {
            return entityContext.ConstructorSet
                .Select(p => p);
        }

        protected override Constructor GetEntity(ManagementDbContext entityContext, int id)
        {
            return entityContext.ConstructorSet
                .Where(p => p.Id == id)
                .Select(p => p)
                .FirstOrDefault();
        }

        protected override IEnumerable<Constructor> GetEntities(ManagementDbContext entityContext, 
            Expression<Func<Constructor, bool>> where, bool onlyFirstLevel)
        {
            return entityContext.ConstructorSet
                .Where(where).Select(p => p);
        }
    }
}
