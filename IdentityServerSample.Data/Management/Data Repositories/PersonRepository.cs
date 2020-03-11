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
    [Export(typeof(IPersonRepository))]
    // Not Shared Creation Policy so as not to create singleton (MEF) - Read on that too
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PersonRepository : PersonDataRepositoryBase <Person>, IPersonRepository
    {
        protected override Person AddEntity(ManagementDbContext entityContext, Person entity)
        {
            return entityContext.PersonSet.Add(entity);
        }

        protected override Person UpdateEntity(ManagementDbContext entityContext, Person entity)
        {
            return entityContext.PersonSet
                .Include(p => p.PhoneNumbers.Select(pn => pn.PhoneNumber))
                .Include(p => p.Addresses.Select(a => a.Address))
                .Include(p => p.Emails.Select(e => e.Email))
                .Where(p => p.Id == entity.Id)
                .Select(p => p)
                .FirstOrDefault();
        }

        protected override IEnumerable<Person> GetEntities(ManagementDbContext entityContext, bool onlyFirstLevel)
        {
            return onlyFirstLevel ?
                entityContext.PersonSet.Select(p => p) :
                entityContext.PersonSet
                .Include(p => p.PhoneNumbers.Select(pn => pn.PhoneNumber))
                .Include(p => p.Addresses.Select(a => a.Address))
                .Include(p => p.Emails.Select(e => e.Email))
                .Select(p => p);
        }

        protected override Person GetEntity(ManagementDbContext entityContext, int id)
        {
            return entityContext.PersonSet
                .Include(p => p.PhoneNumbers.Select(pn => pn.PhoneNumber))
                .Include(p => p.Addresses.Select(a => a.Address))
                .Include(p => p.Emails.Select(e => e.Email))
                .Where(p => p.Id == id)
                .Select(p => p)
                .FirstOrDefault();
        }

        protected override IEnumerable<Person> GetEntities(ManagementDbContext entityContext, Expression<Func<Person, bool>> where, bool onlyFirstLevel)
        {
            return entityContext.PersonSet
                .Include(p => p.PhoneNumbers.Select(pn => pn.PhoneNumber))
                .Include(p => p.Addresses.Select(a => a.Address))
                .Include(p => p.Emails.Select(e => e.Email))
                .Where(where).Select(p => p);
        }
        protected override IEnumerable<Person> GetPersonsWithoutResearcher(ManagementDbContext entityContext)
        {
            using (var context = entityContext)
            {
                var persons = context.PersonSet.SqlQuery("select t1.Id, t1. UserId, t1.MiddleName, t1.Gender, t1.IdentityCardNumber, t1.Notes,t1.TaxCode,t1.RowVersion, t1.IsExpatriate,t1.IsInterestedResearchCyprus, t1.JobTitle, t1.Country, t1.Title, t1.OrganizationTitle, t1.Nationality, t1.IsActive,t1.DateCreated, t1.DateModified, t1.DateOfBirth, t1.CreatedBy, t1.ModifiedBy, t1.UNIC, t1.FirstName, t1.LastName, t1.Email, t1.ChangeInfoRequest from Person t1 left join Researcher t2 on t2.Id = t1.Id where t2.Id is null ").ToList();
                return persons;
            }
        }

        protected override IEnumerable<Person> GetAllResearcherForStatistics(ManagementDbContext entityContext)
        {
            using (var context = entityContext)
            {
                var persons = context.PersonSet.SqlQuery("select Person.Id, Person.UserId, Person.UNIC, Person.Gender, Person.IdentityCardNumber, Person.Notes, Person.TaxCode, Person.RowVersion, Person.IsExpatriate, Person.IsInterestedResearchCyprus, Person.JobTitle, Person.Country, Person.Title, Person.OrganizationTitle, Person.Nationality, Person.IsActive, Person.DateCreated, Person.DateModified, Person.DateOfBirth, Person.CreatedBy, Person.ModifiedBy, Person.FirstName, Person.MiddleName, Person.LastName, Person.Email, Person.ChangeInfoRequest from Person join Researcher on Researcher.Id = Person.Id").ToList();
                return persons;
            }
        }
    }
}
