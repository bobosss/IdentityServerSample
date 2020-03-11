using Auditor.Business.Models;
using Auditor.Data.Management.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Auditor.Data.Management
{
    /// <summary>
    /// Entity Framework DbContext for Auditor Registries and Profiles Management
    /// </summary>
    public class ManagementDbContext : AuditorDbContextBase
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ManagementDbContext() : base("Management")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        #endregion

        #region DbContext Properties - Entities

        #region Draft Management Entities

        /// <summary>
        /// Person Entity Set
        /// </summary>
        public DbSet<Person> PersonSet { get; set; }

        /// <summary>
        /// Person Address Entity Set
        /// </summary>
        public DbSet<PersonAddress> PersonAddressSet { get; set; }
        /// <summary>
        /// Person Phone Number Entity Set
        /// </summary>
        public DbSet<PersonPhoneNumber> PersonPhoneNumberSet { get; set; }
        /// <summary>
        /// Person Email Entity Set
        /// </summary>
        public DbSet<PersonEmail> PersonEmailSet { get; set; }

        /// <summary>
        /// Address Entity Set
        /// </summary>
        public DbSet<Address> AddressSet { get; set; }
        /// <summary>
        /// PhoneNumber Entity Set
        /// </summary>
        public DbSet<PhoneNumber> PhoneNumberSet { get; set; }
        /// <summary>
        /// Email Entity Set
        /// </summary>
        public DbSet<Email> EmailSet { get; set; }

        /// <summary>
        /// Lookup Type Entity Set
        /// </summary>
        public DbSet<LookupType> LookupTypeSet { get; set; }
        /// <summary>
        /// Lookup Entity Set
        /// </summary>
        public DbSet<Lookup> LookupSet { get; set; }

        /// <summary>
        /// Website Entity Set
        /// </summary>
        public DbSet<Website> WebsiteSet { get; set; }

        /// <summary>
        /// Country Entity Set
        /// </summary>
        public DbSet<Country> CountrySet { get; set; }
        /// <summary>
        /// City Entity Set
        /// </summary>
        public DbSet<City> CitySet { get; set; }
	
	    /// <summary>
        /// Maintenance Entity Set
        /// </summary>
        public DbSet<Maintenance> MaintenanceSet { get; set; }

        /// <summary>
        /// Config Entity Set
        /// </summary>
        public DbSet<Config> ConfigSet { get; set; }

        /// <summary>
        /// Scheduled Task Set
        /// </summary>
        public DbSet<ScheduledTask> ScheduledTaskSet { get; set; }

        /// <summary>
        /// Organization Set
        /// </summary>
        public DbSet<Organization> OrganizationSet { get; set; }

        /// <summary>
        /// Constructor Set
        /// </summary>
        public DbSet<Constructor> ConstructorSet { get; set; }
        #endregion

        /// <summary>
        /// Help Desk Issues
        /// </summary>
        public DbSet<Issue> IssueSet { get; set; }

        /// <summary>
        /// IdPool
        /// </summary>
        public DbSet<IdPool> IdPoolSet { get; set; }


        /// <summary>
        /// FileData
        /// </summary>
        public DbSet<FileData> FileDataSet { get; set; }


        /// <summary>
        /// InformationDocument
        /// </summary>
        public DbSet<InformationDocument> InformationDocumentSet { get; set; }


        #endregion

        #region Fluent API Configuration Section

        /// <summary>
        /// Entity Framework DbContext, entities configuration with Fluent API
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder builder)

        {
            #region Draft Entities Configurations

            builder.ApplyConfigurationsFromAssembly(typeof(CityEntityConfiguration).Assembly);
            base.OnModelCreating(builder);

            #endregion

        }

        #endregion

        #region SaveChanges Overrides


        #endregion
    }
}
