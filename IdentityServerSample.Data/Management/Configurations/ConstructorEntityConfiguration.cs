using System.Data.Entity.ModelConfiguration;
using Auditor.Business.Models;
using Auditor.Common;

namespace Auditor.Data.Management.Configurations
{
    /// <summary>
    /// Configures the <see cref="Constructor">Constructor</see> domain class
    /// for the <see cref="ManagementDbContext">Management DbContext </see>.
    /// </summary>
    public class ConstructorEntityConfiguration : IEntityTypeConfiguration<Constructor>
    {
        public ConstructorEntityConfiguration()
        {
            HasKey(p => p.Id);

            builder.Property(p => p.ConstructorsName)
                .HasMaxLength(DataAnnotationConstants.TitleLength);
            builder.Property(p => p.ConstructorsAddress)
                .HasMaxLength(DataAnnotationConstants.TitleLength);
            builder.Property(p => p.ConstructorsCountry)
                .HasMaxLength(DataAnnotationConstants.TitleLength);
            
        }
    }
}
