using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JuanBosch.App.Models.Address;

namespace JuanBosch.App.Data.Configurations
{
    public class SectorConfiguration : IEntityTypeConfiguration<Sector>
    {
        public void Configure(EntityTypeBuilder<Sector> builder)
        {
            builder.ToTable("Sectors");
            
            builder.HasKey(s => s.SectorId);
            
            builder.Property(s => s.SectorId)
                .ValueGeneratedOnAdd();
                
            builder.Property(s => s.SectorName)
                .IsRequired()
                .HasMaxLength(100);
                
            // Relationships
            builder.HasOne(s => s.Municipality)
                .WithMany()
                .HasForeignKey(s => s.MunicipalityId)
                .OnDelete(DeleteBehavior.Cascade);
                
            builder.HasMany(s => s.PatientDirections)
                .WithOne(pd => pd.Sector)
                .HasForeignKey(pd => pd.SectorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.DoctorAddresses)
                .WithOne(da => da.Sector)
                .HasForeignKey(da => da.SectorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
