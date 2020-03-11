using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Auditor.Business.Models;
using Auditor.Common;

namespace Auditor.Data.Management.Configurations
{
    public class InformationDocumentEntityConfiguration : IEntityTypeConfiguration<InformationDocument>
    {
        public void Configure(EntityTypeBuilder<InformationDocument> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Category)
                .HasMaxLength(DataAnnotationConstants.CodeLength);
            builder.Property(p => p.Title)
                .HasMaxLength(DataAnnotationConstants.TitleLength);
            builder.Property(p => p.Description)
                .HasMaxLength(DataAnnotationConstants.DescriptionLength);

            builder.HasOne(p => p.File)
                .WithMany()
                .HasForeignKey(p => p.FileId);

        }
    }

}
