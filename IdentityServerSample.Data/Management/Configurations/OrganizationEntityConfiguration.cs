using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Auditor.Business.Models;
using Auditor.Common;

namespace Auditor.Data.Management.Configurations
{
    /// <summary>
    /// Configures the <see cref="Organization">Maintenance</see> domain class for the <see cref="ManagementDbContext">Management DbContext </see>.
    /// </summary>
    public class OrganizationEntityConfiguration : IEntityTypeConfiguration<Organization>
    {
        /// <summary>
        /// ctor
        /// </summary>
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasKey(p => p.Id);

            #region Data Annotations
            builder.Property(p => p.CompanyTitle)
                .HasMaxLength(DataAnnotationConstants.TitleLength)
                .IsRequired();
            builder.Property(p => p.Street)
                .HasMaxLength(DataAnnotationConstants.TitleLength)
                .IsRequired();
            builder.Property(p => p.StreetNo)
                .HasMaxLength(DataAnnotationConstants.Twentyfive)
                .IsRequired();
            builder.Property(p => p.City)
                .HasMaxLength(DataAnnotationConstants.Fifty)
                .IsRequired();
            builder.Property(p => p.PostCode)
                .HasMaxLength(DataAnnotationConstants.PostcodeLength)
                .IsRequired();
            builder.Property(p => p.VatNumber)
                .HasMaxLength(DataAnnotationConstants.VatLength)
                .IsRequired();
            builder.Property(p => p.Telephone)
                .HasMaxLength(DataAnnotationConstants.TelephoneLength)
                .IsRequired();
            builder.Property(p => p.Fax)
                .HasMaxLength(DataAnnotationConstants.TelephoneLength)
                .IsRequired();
            builder.Property(p => p.Email)
                .HasMaxLength(DataAnnotationConstants.Fifty)
                .IsRequired();
            #endregion

            #region Relationships

            #endregion
        }
    }
}
