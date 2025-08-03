using JuanBosch.App.Models.PatientsDoctors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JuanBosch.App.Data.Configurations.PatientDoctors
{
    public class PatientDoctorConfiguration : IEntityTypeConfiguration<PatientsDoctor>
    {
        public void Configure(EntityTypeBuilder<PatientsDoctor> builder)
        {
            // Table configuration
            builder.ToTable("PatientDoctors");
            builder.HasKey(p => p.PatientDoctorId);
            
            // Primary key configuration
            builder.Property(p => p.PatientDoctorId)
                .ValueGeneratedOnAdd();

            // Foreign keys are automatically required since they're non-nullable int types

            // Unique constraint to prevent duplicate relationships
            builder.HasIndex(p => new { p.DoctorId, p.PatientId })
                .IsUnique()
                .HasDatabaseName("IX_PatientDoctor_DoctorId_PatientId");

            // Relationship configurations
            builder.HasOne(p => p.Patient)
                .WithMany(m => m.PatientDoctor)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.DoctorMedic)
                .WithMany(d => d.PatientDoctor)
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}