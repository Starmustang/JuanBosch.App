using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JuanBosch.App.Models;

namespace JuanBosch.App.Data.Configurations
{
    public class PatientDirectionConfiguration : IEntityTypeConfiguration<PatientDirection>
    {
        public void Configure(EntityTypeBuilder<PatientDirection> builder)
        {
            builder.ToTable("PatientDirections");
            
            builder.HasKey(pd => pd.AddressId);
            
            builder.Property(pd => pd.AddressId)
                .ValueGeneratedOnAdd();
                
            builder.Property(pd => pd.HouseNumber)
                .IsRequired()
                .HasMaxLength(20);
                
            builder.Property(pd => pd.HouseStreet)
                .IsRequired()
                .HasMaxLength(200);
                
            // Relationships
            builder.HasOne(pd => pd.Sector)
                .WithMany(s => s.PatientDirections)
                .HasForeignKey(pd => pd.SectorId)
                .OnDelete(DeleteBehavior.Restrict);
                
            builder.HasOne(pd => pd.Patient)
                .WithOne(p => p.PatientDirection)
                .HasForeignKey<Patient>(p => p.AddressId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
