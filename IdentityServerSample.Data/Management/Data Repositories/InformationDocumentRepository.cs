using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq.Expressions;
using Auditor.Business.Models;
using Auditor.Data.Contracts.Repository_Interfaces.Management;

namespace Auditor.Data.Management.Data_Repositories
{
    [Export(typeof(IInformationDocumentRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class InformationDocumentRepository : DataRepositoryBase<InformationDocument>, IInformationDocumentRepository
    {
        protected override InformationDocument AddEntity(ManagementDbContext entityContext, InformationDocument infodocument)
        {
            return entityContext.InformationDocumentSet.Add(infodocument);
        }

        protected override InformationDocument UpdateEntity(ManagementDbContext entityContext, InformationDocument infodocument)
        {
            return entityContext.InformationDocumentSet
                .Where(r => r.Id == infodocument.Id)
                .Select(r => r)
                .FirstOrDefault();
        }

        protected override IEnumerable<InformationDocument> GetEntities(ManagementDbContext entityContext, bool onlyFirstLevel)
        {
            return entityContext.InformationDocumentSet
                .Include(p => p.File)
                .Select(x => x);
        }


        protected override InformationDocument GetEntity(ManagementDbContext entityContext, int id)
        {
            return entityContext.InformationDocumentSet
                .Include(p => p.File)
                .Where(r => r.Id == id)
                .Select(r => r)
                .FirstOrDefault();
        }

        protected override IEnumerable<InformationDocument> GetEntities(ManagementDbContext entityContext, Expression<Func<InformationDocument, bool>> where, bool onlyFirstLevel)
        {
            return entityContext.InformationDocumentSet.Where(where).Select(p => p);
        }
    }
}
