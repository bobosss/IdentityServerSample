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
    [Export(typeof(IFileDataRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FileDataRepository : DataRepositoryBase<FileData>, IFileDataRepository
    {
        protected override FileData AddEntity(ManagementDbContext entityContext, FileData entity)
        {
            return entityContext.FileDataSet.Add(entity);
        }

        protected override FileData UpdateEntity(ManagementDbContext entityContext, FileData entity)
        {
            return entityContext.FileDataSet
                .Where(r => r.Id == entity.Id)
                .Select(p => p)
                .FirstOrDefault();
        }

        protected override IEnumerable<FileData> GetEntities(ManagementDbContext entityContext, bool onlyFirstLevel)
        {
            return entityContext.FileDataSet
                .Select(p => p);
        }

        protected override FileData GetEntity(ManagementDbContext entityContext, int id)
        {
            return entityContext.FileDataSet
                .Where(r => r.Id == id)
                .FirstOrDefault();
        }

        protected override IEnumerable<FileData> GetEntities(ManagementDbContext entityContext, Expression<Func<FileData, bool>> where, bool onlyFirstLevel)
        {
            return entityContext.FileDataSet
                .Where(where)
                .Select(p => p);
        }
    }
}