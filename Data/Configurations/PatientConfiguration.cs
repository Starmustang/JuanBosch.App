using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JuanBosch.App.Models;

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
                
            builder.Property(p => p.PatientGender)
                .HasMaxLength(20);
                
            builder.Property(p => p.PatientEmail)
                .HasMaxLength(100);
                
            builder.Property(p => p.PatientPhone)
                .HasMaxLength(20);
                
            // Configure table with check constraint
            builder.ToTable(t => 
                t.HasCheckConstraint(
                    "CK_Patient_Identification",
                    "PatientIdCard IS NOT NULL OR PatientPassport IS NOT NULL"
                )
            );
                
            // Indexes for faster lookups
            builder.HasIndex(p => p.PatientIdCard);
            builder.HasIndex(p => p.PatientPassport);
            builder.HasIndex(p => p.PatientEmail);
            
            // Relationship with PatientDirection is configured in PatientDirectionConfiguration
        }
    }
}
