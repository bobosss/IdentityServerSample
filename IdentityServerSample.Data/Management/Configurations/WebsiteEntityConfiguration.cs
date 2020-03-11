using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Auditor.Business.Models;
using Auditor.Common;

namespace Auditor.Data.Management.Configurations
{
    public class WebsiteEntityConfiguration : IEntityTypeConfiguration<Website>
    {
        public void Configure(EntityTypeBuilder<Website> builder)
        {
            builder.HasKey(pn => pn.Id);

            builder.Property(pn => pn.Url)
                .HasMaxLength(DataAnnotationConstants.TitleLength)
                .IsRequired();
        }
    }

}
