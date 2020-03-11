using Auditor.Business.Models;
using Auditor.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auditor.Data.Management.Configurations
{
    public class ConfigEntityConfiguration : IEntityTypeConfiguration<Config>
    {
        public void Configure(EntityTypeBuilder<Config> builder)
        {
            builder.HasKey(pn => pn.Id);

            builder.Property(pn => pn.Key)
                .HasMaxLength(DataAnnotationConstants.TitleLength)
                .IsRequired();

            builder.Property(pn => pn.Value)
                .HasMaxLength(DataAnnotationConstants.LargeComments)
                .IsRequired();
        }
    }
}