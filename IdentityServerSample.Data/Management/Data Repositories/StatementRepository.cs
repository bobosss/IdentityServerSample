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
    [Export(typeof(IStatementRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StatementRepository : DataRepositoryBase<Statement>, IStatementRepository
    {
        protected override Statement AddEntity(ManagementDbContext entityContext, Statement entity)
        {
            return entityContext.StatementSet.Add(entity);
        }

        protected override Statement UpdateEntity(ManagementDbContext entityContext, Statement entity)
        {
            return entityContext.StatementSet
                .Where(r => r.Id == entity.Id)
                .Select(r => r)
                .FirstOrDefault();
        }

        protected override IEnumerable<Statement> GetEntities(ManagementDbContext entityContext, bool onlyFirstLevel)
        {
            return entityContext.StatementSet
                .Include(x => x.Organization)
                .Select(r => r);
        }

        protected override Statement GetEntity(ManagementDbContext entityContext, int id)
        {
            return entityContext.StatementSet
                .Include(x=>x.Adapter)
                .Include(x=>x.Extension)
                .Include(x => x.FixedConnector)
                .Include(x => x.Multiprice)
                .Include(x => x.PortableConnector)
                .Include(x => x.PortablePlug)
                .Include(x => x.Organization)
                .Where(r => r.Id == id)
                .Select(r => r)
                .FirstOrDefault();
        }

        protected override IEnumerable<Statement> GetEntities(ManagementDbContext entityContext, Expression<Func<Statement, bool>> where, bool onlyFirstLevel)
        {
            return entityContext.StatementSet.Where(where).Select(p => p);
        }
    }
}
