using Auditor.Business.Models;
using Auditor.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auditor.Data.Management.Configurations
{
    /// <summary>
    /// Configures the <see cref="Person">Person</see> domain class
    /// for the <see cref="ManagementDbContext">Management DbContext </see>.
    /// </summary>
    public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName)
                .HasMaxLength(DataAnnotationConstants.TitleLength)
                .IsRequired();
            builder.Property(p => p.LastName)
                .HasMaxLength(DataAnnotationConstants.TitleLength)
                .IsRequired();
            builder.Property(p => p.MiddleName)
                .HasMaxLength(DataAnnotationConstants.TitleLength);
            builder.Property(p => p.Email)
                .HasMaxLength(DataAnnotationConstants.TitleLength);
            builder.Property(p => p.IdentityCardNumber)
                .HasMaxLength(DataAnnotationConstants.IdentityCardNumber);
            builder.Property(p => p.TaxCode)
                .HasMaxLength(DataAnnotationConstants.TaxCode);
            builder.Property(p => p.OrganizationTitle)
                .HasMaxLength(DataAnnotationConstants.TitleLength);
            builder.Property(p => p.Title)
                .HasMaxLength(DataAnnotationConstants.CodeLength);
            builder.Property(p => p.JobTitle)
                .HasMaxLength(DataAnnotationConstants.TitleLength);
            builder.Property(p => p.Gender)
                .HasMaxLength(DataAnnotationConstants.CodeLength);
            builder.Property(p => p.Nationality)
                .HasMaxLength(DataAnnotationConstants.CodeLength);
            builder.Property(p => p.Notes)
                .HasMaxLength(DataAnnotationConstants.LargeComments);
            builder.Property(p => p.Country)
                .HasMaxLength(DataAnnotationConstants.CodeLength);
           
            // Optimistic Concurency Token
            // https://msdn.microsoft.com/en-us/data/jj591617.aspx
            builder.Property(l => l.RowVersion)
                .IsRowVersion();


            // "1-to-many" relationship from Person to Addresses/PhoneNumbers/Emails with intermediate table
            // resembles "many-to-many" relationship (convenient convention)
            builder.HasMany(r => r.Addresses)
                .WithOne(f => f.Person)
                .HasForeignKey(f => f.PersonId);
            builder.HasMany(r => r.PhoneNumbers)
                .WithOne(f => f.Person)
                .HasForeignKey(f => f.PersonId);
            builder.HasMany(r => r.Emails)
                .WithOne(f => f.Person)
                .HasForeignKey(f => f.PersonId);


            // note about cascade on delete (writing it here to be a reference for all entities):
            // - what it means: leave no orphans (when parent is deleted, child should be deleted, too)
            // The convention says: it's on in "required" cases.
            // - default value of cascade on delete:
            // -- if your relationship/navigation builder.Property is "required", it is true.
            // -- if your relationship/navigation builder.Property is "optional", it is false.
            // - parameterless cascade on delete means true
        }
    }

    

    public class PersonAddressEntityConfiguration : IEntityTypeConfiguration<PersonAddress>
    {
        public void Configure(EntityTypeBuilder<PersonAddress> builder)
        {
            builder.HasKey(m => m.Id);

            // "1-to-1" relationship from PersonAddress to Address
            builder.HasOne(m => m.Address)
                .WithMany()
                .HasForeignKey(m => m.AddressId);
        }
    }

    public class PersonPhoneNumberEntityConfiguration : IEntityTypeConfiguration<PersonPhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PersonPhoneNumber> builder)

        {
            builder.HasKey(m => m.Id);

            // "1-to-1" relationship from PersonPhoneNumber to PhoneNumber
            builder.HasOne(m => m.PhoneNumber)
                .WithMany()
                .HasForeignKey(m => m.PhoneNumberId);
        }
    }

    public class PersonEmailEntityConfiguration : IEntityTypeConfiguration<PersonEmail>
    {
        public void Configure(EntityTypeBuilder<PersonEmail> builder)
        {
            builder.HasKey(m => m.Id);

            // "1-to-1" relationship from PersonEmail to Email
            builder.HasOne(m => m.Email)
                .WithMany()
                .HasForeignKey(m => m.EmailId);
        }
    }

    

}
