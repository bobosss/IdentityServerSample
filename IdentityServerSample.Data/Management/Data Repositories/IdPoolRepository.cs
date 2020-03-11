using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using System.Linq.Expressions;
using Auditor.Business.Models;
using Auditor.Data.Contracts.Repository_Interfaces.Management;

namespace Auditor.Data.Management.Data_Repositories
{
    [Export(typeof(IIdPoolRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class IdPoolRepository : IdPoolRepositoryBase<IdPool>, IIdPoolRepository
    {
        protected override IdPool AddEntity(ManagementDbContext entityContext, IdPool entity)
        {
            return entityContext.IdPoolSet.Add(entity);
        }

        protected override IdPool UpdateEntity(ManagementDbContext entityContext, IdPool entity)
        {
            return entityContext.IdPoolSet
                .Where(r => r.Id == entity.Id)
                .Select(r => r)
                .FirstOrDefault();
        }

        protected override IEnumerable<IdPool> GetEntities(ManagementDbContext entityContext, bool onlyFirstLevel)
        {
            return entityContext.IdPoolSet
                .Select(x => x);
        }

        protected override IdPool GetEntity(ManagementDbContext entityContext, string classname)
        {
            int PICLength = 10;
            switch (classname)
            {
                case "Person":
                    PICLength = 5;
                    break;
                case "Organization":
                    PICLength = 10;
                    break;
                case "Issue":
                    PICLength = 4;
                    break;
            }
            return entityContext.IdPoolSet
                .Where(r => r.Assigned == false)
                .Where(r => r.RandomNum.Length == PICLength)
                .Select(r => r)
                .OrderBy(r => Guid.NewGuid())
                .FirstOrDefault();
        }

        protected override IdPool GetEntity(ManagementDbContext entityContext, int id)
        {
            return entityContext.IdPoolSet
                .Where(r => r.Id == id)
                .Select(r => r)
                .FirstOrDefault();
        }

        protected override IEnumerable<IdPool> GetEntities(ManagementDbContext entityContext,
            Expression<Func<IdPool, bool>> where, bool onlyFirstLevel)
        {
            return entityContext.IdPoolSet.Where(where).Select(p => p);
        }

        protected override int GetNextSequenceNumber(ManagementDbContext entityContext, string sec)
        {
            var rawQuery = entityContext.Database.SqlQuery<int>(
                "select current_value from sys.sequences where name = '" + sec + "';");
            int nextVal = rawQuery.Single() + 1;
            return nextVal;
        }

        protected override int ApplyNextSequenceNumber(ManagementDbContext entityContext, string sec)
        {
            var rawQuery = entityContext.Database.SqlQuery<int>(
                "select next value for " + sec + ";");
            int nextVal = rawQuery.Single();
            return nextVal;
        }

    }
}
