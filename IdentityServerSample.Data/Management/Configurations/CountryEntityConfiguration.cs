using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Auditor.Business.Models;

namespace Auditor.Data.Management.Configurations
{
    public class CountryEntityConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            //builder.HasKey(p => p.Code);
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Code)
                .HasMaxLength(2)
                .IsRequired();
            builder.Property(p => p.CodeISO3)
                .HasMaxLength(3)
                .IsRequired();
            builder.Property(p => p.CodeISONum)
                .IsRequired();
            builder.Property(p => p.FipsCode)
                .HasMaxLength(2);
            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(p => p.Capital)
                .HasMaxLength(30);
            builder.Property(p => p.Area)
                .HasColumnType("decimal(10,5)")
                .IsRequired();
            builder.Property(p => p.Population)
                .IsRequired();
            builder.Property(p => p.ContinentCode)
                .HasMaxLength(2)
                .IsRequired();
            builder.Property(p => p.TldCode)
                .HasMaxLength(3);
            builder.Property(p => p.CurrencyCode)
                .HasMaxLength(3);
            builder.Property(p => p.CurrencyName)
                .HasMaxLength(20);
            builder.Property(p => p.PhonePrefix)
                .HasMaxLength(20);
            builder.Property(p => p.PostalCodeFormat)
                .HasMaxLength(60);
            builder.Property(p => p.PostalCodeRegex)
                .HasMaxLength(200);
            builder.Property(p => p.Languages)
                .HasMaxLength(100);
            builder.Property(p => p.GeoNameId)
                .IsRequired();
            builder.Property(p => p.Neighbours)
                .HasMaxLength(50);
            builder.Property(p => p.EquivalentFipsCode)
                .HasMaxLength(2);
            builder.Property(p => p.Nationality)
                .HasMaxLength(80);
        }
    }
}
