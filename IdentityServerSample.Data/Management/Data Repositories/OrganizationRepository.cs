using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using Auditor.Business.Models;
using Auditor.Data.Contracts.Repository_Interfaces.Management;
using System.Data.Entity;

namespace Auditor.Data.Management.Data_Repositories
{
    [Export(typeof(IOrganizationRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OrganizationRepository : DataRepositoryBase<Organization>, IOrganizationRepository
    {
        protected override Organization AddEntity(ManagementDbContext entityContext, Organization entity)
        {
            return entityContext.OrganizationSet.Add(entity);
        }

        protected override Organization UpdateEntity(ManagementDbContext entityContext, Organization entity)
        {
            return entityContext.OrganizationSet
                .Where(r => r.Id == entity.Id)
                .Select(r => r)
                .FirstOrDefault();
        }

        protected override IEnumerable<Organization> GetEntities(ManagementDbContext entityContext, bool onlyFirstLevel)
        {
            return entityContext.OrganizationSet.Select(r => r);
        }

        protected override Organization GetEntity(ManagementDbContext entityContext, int id)
        {
            return entityContext.OrganizationSet
                .Include(x => x.Statements)
                .Where(r => r.Id == id)
                .Select(r => r)
                .FirstOrDefault();
        }

        protected override IEnumerable<Organization> GetEntities(ManagementDbContext entityContext, Expression<Func<Organization, bool>> where, bool onlyFirstLevel)
        {
            return entityContext.OrganizationSet.Where(where).Select(p => p);
        }
    }
}
