using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Auditor.Business.Models;
using Auditor.Common;

namespace Auditor.Data.Management.Configurations
{
    /// <summary>
    /// Configures the <see cref="Maintenance">Maintenance</see> domain class for the <see cref="ManagementDbContext">Management DbContext </see>.
    /// </summary>
    public class MaintenanceEntityConfiguration : IEntityTypeConfiguration<Maintenance>
    {
        /// <summary>
        /// ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<Maintenance> builder)
        {
            builder.HasKey(p => p.Id);
           
            builder.Property(p => p.Message )
                .HasMaxLength(DataAnnotationConstants.TitleLength)
                .IsRequired();
            builder.Property(p => p.StartTime)
                .IsRequired();
            builder.Property(p => p.EndTime);

        }
    }
}
