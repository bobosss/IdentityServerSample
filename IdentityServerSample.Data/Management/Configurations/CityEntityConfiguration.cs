using Auditor.Business.Models;
using Auditor.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auditor.Data.Management.Configurations
{
    public class CityEntityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Users", "User");

            builder.HasKey(x => x.Id);


            builder.Property(p => p.GeoNameId)
                .IsRequired();
            builder.Property(p => p.Name)
                .HasMaxLength(60)
                .IsRequired();
            builder.Property(p => p.AsciiName)
                .HasMaxLength(60);
            builder.Property(p => p.AlternateNames)
                .HasMaxLength(2500);
            builder.Property(p => p.Latitude)
                .HasColumnType("decimal(10,5)")
                .IsRequired();
            builder.Property(p => p.Longitude)
                .HasColumnType("decimal(10,5)")
                .IsRequired();
            builder.Property(p => p.FeatureClassCode)
                .HasMaxLength(1)
                .IsRequired();
            builder.Property(p => p.FeatureCode)
                .HasMaxLength(10)
                .IsRequired();
            builder.Property(p => p.CountryCode)
                .HasMaxLength(2)
                .IsRequired();
            builder.Property(p => p.CountryCodesAlternate)
                .HasMaxLength(DataAnnotationConstants.CodeLength);
            builder.Property(p => p.GeoDivision1Code)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(p => p.GeoDivision2Code)
                .HasMaxLength(50);
            builder.Property(p => p.GeoDivision3Code)
                .HasMaxLength(10);
            builder.Property(p => p.GeoDivision4Code)
                .HasMaxLength(10);
            builder.Property(p => p.Population)
                .IsRequired();
            builder.Property(p => p.DigitalElevationModel)
                .IsRequired();
            builder.Property(p => p.Timezone)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(p => p.GeoModificationDate)
                .IsRequired();
            /*
            HasRequired(p => p.Country)
                .WithMany()
                .HasForeignKey(c => c.CountryCode)
                .WillCascadeOnDelete(false);
            HasRequired(p => p.GeoDivision1)
                .WithMany()
                .HasForeignKey(c => new { c.CountryCode, c.GeoDivision1Code })
                .WillCascadeOnDelete(false);
            HasOptional(p => p.GeoDivision2)
                .WithMany()
                .HasForeignKey(c => new { c.CountryCode, c.GeoDivision1Code, c.GeoDivision2Code })
                .WillCascadeOnDelete(false);
            HasRequired(p => p.FeatureGeoCodes)
                .WithMany()
                .HasForeignKey(c => new { c.FeatureClassCode, c.FeatureCode})
                .WillCascadeOnDelete(false);
            */
        }
    }
}
