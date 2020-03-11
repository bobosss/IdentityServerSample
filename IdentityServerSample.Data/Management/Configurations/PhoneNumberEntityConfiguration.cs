using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Auditor.Business.Models;
using Auditor.Common;

namespace Auditor.Data.Management.Configurations
{
    public class PhoneNumberEntityConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)

        {
            builder.HasKey(pn => pn.Id);
            
            builder.Property(pn => pn.PhoneNumberType)
                .HasMaxLength(DataAnnotationConstants.CodeLength)
                .IsRequired();
            builder.Property(pn => pn.Number)
                .HasMaxLength(DataAnnotationConstants.PhoneNumberLength)
                .IsRequired();
        }
    }

}
