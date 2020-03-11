using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Auditor.Business.Models;
using Auditor.Common;

namespace Auditor.Data.Management.Configurations
{
    public class LookupEntityConfiguration : IEntityTypeConfiguration<Lookup>
    {
        public void Configure(EntityTypeBuilder<Lookup> builder)
        {
            builder.HasKey(lup => lup.Id);
            builder.Property(lup => lup.Code)
                .IsRequired()
                .HasMaxLength(DataAnnotationConstants.CodeLength);
            builder.HasIndex("Code", "LookupTypeId")
                .IsUnique();

            builder.Property(lup => lup.LookupTypeId)
                .IsRequired();

            builder.Property(lup => lup.Title)
                .HasMaxLength(DataAnnotationConstants.TitleLength);
            builder.Property(lup => lup.Title_en)
                .HasMaxLength(DataAnnotationConstants.TitleLength);
            builder.Property(lup => lup.Title_el)
                .HasMaxLength(DataAnnotationConstants.TitleLength);
            builder.Property(lup => lup.Description_en)
                .HasMaxLength(DataAnnotationConstants.DescriptionLength);
            builder.Property(lup => lup.Description_el)
                .HasMaxLength(DataAnnotationConstants.DescriptionLength);

            // Implementation Notes:
            // mapping from the 'many' side, many-to-one (many Lookup(s) to one LookupType)
            // alternatively we can map from the 'one' side, one-to-many (one LookupType has many Lookup(s))
            // this is a unidirectional map, can navigate from 
            builder.HasOne(lup => lup.LookupType)
                .WithMany(lupT => lupT.Lookups)
                .HasForeignKey(lup => lup.LookupTypeId);


            // implicit through Parent, ParentId, Children
            // so, this is not needed
            /*
            HasOptional(lup => lup.Parent)
                .WithMany(lupT => lupT.Children)
                .HasForeignKey(lup => lup.ParentId)
                .WillCascadeOnDelete(false);
            */
        }
    }
    
    public class LookupTypeEntityConfiguration : IEntityTypeConfiguration<LookupType>
    {
        public void Configure(EntityTypeBuilder<LookupType> builder)
        {
            builder.HasKey(lt => lt.Id);

            builder.Property(lt => lt.Code)
                .IsRequired()
                .HasMaxLength(DataAnnotationConstants.CodeLength);
            builder.HasIndex(p => p.Code)
                .IsUnique();


            builder.Property(lt => lt.Description)
                .IsRequired()
                .HasMaxLength(DataAnnotationConstants.DescriptionLength);
            builder.Property(lt => lt.Description_el)
                .HasMaxLength(DataAnnotationConstants.DescriptionLength);
        }
    }
}
