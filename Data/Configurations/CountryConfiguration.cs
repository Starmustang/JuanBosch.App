using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JuanBosch.App.Models.Address;

namespace JuanBosch.App.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");
            
            builder.HasKey(c => c.CountryId);
            
            builder.Property(c => c.CountryId)
                .ValueGeneratedOnAdd();
                
            builder.Property(c => c.CountryName)
                .IsRequired()
                .HasMaxLength(100);
                
            builder.Property(c => c.CountryLanguage)
                .IsRequired()
                .HasMaxLength(50);
                
            builder.Property(c => c.CountryCurrency)
                .IsRequired()
                .HasMaxLength(10);
                
            // Relationships
            builder.HasMany(c => c.Provinces)
                .WithOne(p => p.Country)
                .HasForeignKey(p => p.CountryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
