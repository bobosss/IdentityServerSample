using System;
using System.ComponentModel.Composition;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Allweb.Core.Common.Contracts;
using Allweb.Core.Common.Core;
using System.Data.Entity.Validation;
using Auditor.Data.Management;
using Microsoft.EntityFrameworkCore;

namespace Auditor.Data
{
    public class AuditorDbContextBase : DbContext
    {
        [Import]
        ILoggerService _loggerService;

        public AuditorDbContextBase() : base()
        {
            if (ObjectBase.Container != null)
                ObjectBase.Container.SatisfyImportsOnce(this);

            //if (_loggerService != null)
            //    Database.Log = s => _loggerService.Debug(s, null);
        }
        public AuditorDbContextBase(DbContextOptions<AuditorDbContextBase> options)
            : base(options)
        {
        }

        public AuditorDbContextBase(string connectionName) : base(connectionName)
        {
            if (ObjectBase.Container != null)
                ObjectBase.Container.SatisfyImportsOnce(this);

             //For Development Purposes Create if not exists
             //Database.SetInitializer<ManagementDbContext>(new CreateDatabaseIfNotExists<ManagementDbContext>());
             //Database.Initialize(false);

            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            //if (_loggerService != null)
            //    Database.Log = s => _loggerService.Debug(s, null);
            Database.Log = null;

            ((IObjectContextAdapter)this).ObjectContext
                .ObjectMaterialized += (sender, args) =>
                {
                    var entity = args.Entity as IEntityState;
                    if (entity != null)
                        entity.State = State.Unchanged;
                };
        }

        public AuditorDbContextBase(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Remove convention about pluralizing table names in database
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Ignore ExtensionData defined in Allweb.Core.Common.Core.ObjectBase to implement IExtensibleDataObject
            modelBuilder.Ignore<ExtensionDataObject>();

            // Do not persist IsDirty helper property
            modelBuilder.Types<IEntityState>().Configure(t => t.Ignore(iEntityState => iEntityState.State));

            base.OnModelCreating(modelBuilder);
        }

        public int UserId { get; set; }

        /// <summary>
        /// DbContext SaveChanges() override to save <see cref="IModificationLog">IModificationLog</see> data.    
        /// </summary>
        public override int SaveChanges()
        {
            foreach (var dbEntityEntry in ChangeTracker.Entries()
                .Where(e => e.Entity is IModificationLog &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified))
                .Select(e => e.Entity as IModificationLog))
            {
                dbEntityEntry.DateModified = DateTime.Now;
                if (dbEntityEntry.DateCreated == DateTime.MinValue)
                    dbEntityEntry.DateCreated = DateTime.Now;
            }
            
            var userId = UserId;

            // just some initial check
            // TODO: finalize this
            if (userId > 0)
            {
                foreach (var dbEntityEntry in ChangeTracker.Entries()
                    .Where(e => e.Entity is IModificationLog && e.State == EntityState.Added)
                    .Select(e => e.Entity as IModificationLog))
                {
                    dbEntityEntry.CreatedBy = userId;
                    dbEntityEntry.ModifiedBy = userId;
                }
                foreach (var dbEntityEntry in ChangeTracker.Entries()
                    .Where(e => e.Entity is IModificationLog && e.State == EntityState.Modified)
                    .Select(e => e.Entity as IModificationLog))
                {
                    dbEntityEntry.ModifiedBy = userId;
                }
            }
            // not needed, already handled in ManagerBase. Also here UpdateIssue can occur with UserId 0 (anonymous)
            //else
            //    _loggerService.Error("User Id initiating changes from Client not valid...");

            int result;
            try
            {
                result = base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    _loggerService.Error("Entity of type \"{0}\" in state \"{1}\" has the following " +
                        "validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        _loggerService.Error("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }

            foreach (var dbEntityEntry in ChangeTracker.Entries()
                .Where(e => e.Entity is IEntityState)
                .Select(e => e.Entity as IEntityState))
                    dbEntityEntry.State = State.Unchanged;

            return result;
        }

        /// <summary>
        /// DbContext SaveChangesAsync() override to save <see cref="IModificationLog">IModificationLog</see> data.   
        /// </summary>
        public override Task<int> SaveChangesAsync()
        {
            foreach (var dbEntityEntry in ChangeTracker.Entries()
                .Where(e => e.Entity is IModificationLog &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified))
                .Select(e => e.Entity as IModificationLog))
            {
                dbEntityEntry.DateModified = DateTime.Now;
                if (dbEntityEntry.DateCreated == DateTime.MinValue)
                    dbEntityEntry.DateCreated = DateTime.Now;
            }
            
            var result = base.SaveChangesAsync();

            foreach (var dbEntityEntry in ChangeTracker.Entries()
                .Where(e => e.Entity is IEntityState)
                .Select(e => e.Entity as IEntityState))
                    dbEntityEntry.State = State.Unchanged;

            return result;
        }

        /// <summary>
        /// DbContext SaveChangesAsync(CancellationToken cancellationToken) override
        /// to save <see cref="IModificationLog">IModificationLog</see> data.  
        /// </summary>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach (var dbEntityEntry in ChangeTracker.Entries()
                .Where(e =>e.Entity is IModificationLog &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified))
                .Select(e => e.Entity as IModificationLog))
            {
                dbEntityEntry.DateModified = DateTime.Now;
                if (dbEntityEntry.DateCreated == DateTime.MinValue)
                    dbEntityEntry.DateCreated = DateTime.Now;
            }
            
            var result = base.SaveChangesAsync(cancellationToken);

            foreach (var dbEntityEntry in ChangeTracker.Entries()
                .Where(e => e.Entity is IEntityState)
                .Select(e => e.Entity as IEntityState))
                    dbEntityEntry.State = State.Unchanged;

            return result;
        }
    }
}
