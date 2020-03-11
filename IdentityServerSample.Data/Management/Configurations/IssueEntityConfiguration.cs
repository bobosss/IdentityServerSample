using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Auditor.Business.Models;
using Auditor.Common;

namespace Auditor.Data.Management.Configurations
{
    public class IssueEntityConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.UNIC)
                .HasMaxLength(DataAnnotationConstants.CodeLength)
                .IsRequired();
            builder.Property(p => p.Subject)
                .HasMaxLength(DataAnnotationConstants.CodeLength);
            builder.Property(p => p.Title)
                .HasMaxLength(DataAnnotationConstants.TitleLength);

            builder.HasOne(p => p.Person)
               .WithMany()
               .HasForeignKey(p => p.PersonId);
            builder.HasOne(p => p.AnonUser)
               .WithMany()
               .HasForeignKey(p => p.AnonUserId);

            builder.HasMany(r => r.IssueFiles)
              .WithOne(cf => cf.Issue)
              .HasForeignKey(cf => cf.IssueId);

        }
    }

    public class AnonUserEntityConfiguration : IEntityTypeConfiguration<AnonUser>
    {
        public void Configure(EntityTypeBuilder<AnonUser> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName)
                .HasMaxLength(DataAnnotationConstants.TitleLength);
            builder.Property(p => p.LastName)
                .HasMaxLength(DataAnnotationConstants.TitleLength);
            builder.Property(p => p.Phone)
                .HasMaxLength(DataAnnotationConstants.PhoneNumberLength);
            builder.Property(p => p.Email)
                .HasMaxLength(DataAnnotationConstants.TitleLength);
        }
    }

    public class IssueFilesEntityConfiguration : IEntityTypeConfiguration<IssueFiles>
    {
        public void Configure(EntityTypeBuilder<IssueFiles> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DocumentName)
                .HasMaxLength(DataAnnotationConstants.TitleLength);
        }
    }
}
