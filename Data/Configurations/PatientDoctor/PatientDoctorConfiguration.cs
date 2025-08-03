using JuanBosch.App.Models.PatientsDoctors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JuanBosch.App.Data.Configurations.PatientDoctors
{
    public class PatientDoctorConfiguration : IEntityTypeConfiguration<PatientsDoctor>
    {
        public void Configure(EntityTypeBuilder<PatientsDoctor> builder)
        {
            builder.ToTable("PatientDoctors");
            builder.HasKey(p => p.PatientDoctorId);
            builder.Property(p => p.PatientDoctorId)
            .ValueGeneratedOnAdd();

            builder.HasOne(p => p.Patient)
            .WithMany(m => m.PatientDoctor)
            .HasForeignKey(m => m.PatientId);

            builder.HasOne(p => p.DoctorMedic)
            .WithMany(d => d.PatientDoctor)
            .HasForeignKey(d => d.DoctorId);
        }
    }
}