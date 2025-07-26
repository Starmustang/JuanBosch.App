using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JuanBosch.App.Models.Address;

namespace JuanBosch.App.Data.Configurations
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable("Provinces");
            
            builder.HasKey(p => p.ProvinceId);
            
            builder.Property(p => p.ProvinceId)
                .ValueGeneratedOnAdd();
                
            builder.Property(p => p.ProvinceName)
                .IsRequired()
                .HasMaxLength(100);
                
            // Relationships
            builder.HasOne(p => p.Country)
                .WithMany(c => c.Provinces)
                .HasForeignKey(p => p.CountryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
