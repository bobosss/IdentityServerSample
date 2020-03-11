using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Auditor.Business.Models;
using Auditor.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auditor.Data.Management.Configurations
{
    public class IdPoolEntityConfiguration : IEntityTypeConfiguration<IdPool>
    {
        public void Configure(EntityTypeBuilder<IdPool> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.RandomNum)
                .HasMaxLength(DataAnnotationConstants.TitleLength);


            builder.HasIndex(p => p.RandomNum)
                .IsUnique();

        }
    }
}
