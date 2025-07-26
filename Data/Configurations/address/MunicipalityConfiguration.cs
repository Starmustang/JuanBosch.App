using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JuanBosch.App.Models.Address;

namespace JuanBosch.App.Data.Configurations
{
    public class MunicipalityConfiguration : IEntityTypeConfiguration<Municipality>
    {
        public void Configure(EntityTypeBuilder<Municipality> builder)
        {
            builder.ToTable("Municipalities");
            
            builder.HasKey(m => m.MunicipalityId);
            
            builder.Property(m => m.MunicipalityId)
                .ValueGeneratedOnAdd();
                
            builder.Property(m => m.MunicipalityName)
                .IsRequired()
                .HasMaxLength(100);
                
            // Relationships
            builder.HasOne(m => m.Province)
                .WithMany()
                .HasForeignKey(m => m.ProvinceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
