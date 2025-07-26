using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JuanBosch.App.Models;
using JuanBosch.App.Models.Patients;

namespace JuanBosch.App.Data.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");
            
            builder.HasKey(p => p.PatientId);
            
            builder.Property(p => p.PatientId)
                .ValueGeneratedOnAdd();
                
            builder.Property(p => p.PatientName)
                .IsRequired()
                .HasMaxLength(100);
                
            builder.Property(p => p.PatientLastName)
                .IsRequired()
                .HasMaxLength(100);
                
            builder.Property(p => p.PatientIdCard)
                .HasMaxLength(30);
                
            builder.Property(p => p.PatientPassport)
                .HasMaxLength(20);

            builder.Property(p => p.PatientBirthDate);
                
                
            builder.Property(p => p.PatientGender)
                .HasMaxLength(20);
                
            builder.Property(p => p.PatientEmail)
                .HasMaxLength(100);
                
            builder.Property(p => p.PatientPhone)
                .HasMaxLength(20);
                
            builder.HasOne(p => p.PatientDirection)
                .WithMany(pd => pd.Patient)
                .HasForeignKey(pd => pd.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.PatientEmergencieContact)
                .HasMaxLength(100);
            
            builder.Property(p => p.PatientFisRecord)
                .HasMaxLength(100);

            builder.HasOne(p => p.ArsPlans)
                .WithMany(a => a.Patients)
                .HasForeignKey(p => p.ArsPlansId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Blood)
                .WithMany(b => b.Patients)
                .HasForeignKey(p => p.BloodId)
                .OnDelete(DeleteBehavior.Restrict);
                
                
            // Indexes for faster lookups
            builder.HasIndex(p => p.PatientIdCard);
            builder.HasIndex(p => p.PatientPassport);
            builder.HasIndex(p => p.PatientEmail);
            
        }
    }
}
