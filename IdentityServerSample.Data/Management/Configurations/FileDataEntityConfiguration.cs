using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Auditor.Business.Models;

namespace Auditor.Data.Management.Configurations
{
    public class FileDataEntityConfiguration : IEntityTypeConfiguration<FileData>
    {
        public void Configure(EntityTypeBuilder<FileData> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FileName)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(p => p.StreamId)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(p => p.Extension)
                .HasMaxLength(8);
            builder.Property(p => p.FileSize)
                .IsRequired();
        }
    }
}
