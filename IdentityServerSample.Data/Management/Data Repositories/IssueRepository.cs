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
    [Export(typeof(IIssueRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class IssueRepository : DataRepositoryBase<Issue>, IIssueRepository
    {
        protected override Issue AddEntity(ManagementDbContext entityContext, Issue entity)
        {
            return entityContext.IssueSet.Add(entity);
        }

        protected override Issue UpdateEntity(ManagementDbContext entityContext, Issue entity)
        {
            return entityContext.IssueSet
                .Include(r => r.Person)
                .Include(r => r.IssueFiles.Select(lf => lf.FileData))
                .Include(r => r.AnonUser)
                .Where(r => r.Id == entity.Id)
                .Select(r => r)
                .FirstOrDefault();
        }

        protected override IEnumerable<Issue> GetEntities(ManagementDbContext entityContext, bool onlyFirstLevel)
        {
            return entityContext.IssueSet
                .Include(r => r.Person)
                .Include(r => r.IssueFiles.Select(lf => lf.FileData))
                .Include(r => r.AnonUser)
                .Select(x => x);
        }

        protected override Issue GetEntity(ManagementDbContext entityContext, int id)
        {
            return entityContext.IssueSet
                .Include(r => r.Person)
                .Include(r => r.IssueFiles.Select(lf => lf.FileData))
                .Include(r => r.AnonUser)
                .Where(r => r.Id == id)
                .Select(r => r)
                .FirstOrDefault();
        }

        protected override IEnumerable<Issue> GetEntities(ManagementDbContext entityContext, 
            Expression<Func<Issue, bool>> where, bool onlyFirstLevel)
        {
            return entityContext.IssueSet.Where(where)
                .Include(r => r.Person)
                .Include(r => r.IssueFiles.Select(lf => lf.FileData))
                .Include(r => r.AnonUser)
                .Select(p => p);
        }
    }
}
