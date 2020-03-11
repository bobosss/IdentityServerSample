using Auditor.Business.Models;
using Auditor.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auditor.Data.Management.Configurations
{
    /// <summary>
    /// Configures the <see cref="Constructor">Constructor</see> domain class
    /// for the <see cref="ManagementDbContext">Management DbContext </see>.
    /// </summary>
    public class ConstructorEntityConfiguration : IEntityTypeConfiguration<Constructor>
    {
        public void Configure(EntityTypeBuilder<Constructor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.ConstructorsName)
                .HasMaxLength(DataAnnotationConstants.TitleLength);
            builder.Property(p => p.ConstructorsAddress)
                .HasMaxLength(DataAnnotationConstants.TitleLength);
            builder.Property(p => p.ConstructorsCountry)
                .HasMaxLength(DataAnnotationConstants.TitleLength);
            
        }
    }
}
