using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JuanBosch.App.Models.Dates;

namespace JuanBosch.App.Data.Configurations.dates
{
    public class DateMedicConfiguration : IEntityTypeConfiguration<DateMedic>
    {
        public void Configure(EntityTypeBuilder<DateMedic> builder)
        {
            builder.ToTable("DateMedics");
            builder.HasKey(d => d.DateMedicId);
            builder.Property(d => d.DateMedicId)
            .ValueGeneratedOnAdd();

            builder.Property(d => d.DateMedicDate)
            .IsRequired();

            builder.Property(d => d.HospitalMedicDate)
            .IsRequired()
            .HasMaxLength(25);

            builder.HasOne(d => d.Patient)
            .WithMany(p => p.DateMedics)
            .HasForeignKey(d => d.PatientId);
            
            builder.HasOne(d => d.Doctor)
            .WithMany(p => p.DateMedics)
            .HasForeignKey(d => d.DoctorId);

            builder.HasOne(d => d.ConsultationType)
            .WithMany(p => p.DateMedics)
            .HasForeignKey(d => d.ConsultationTypeId);

            builder.HasOne(d => d.DateDoctor)
            .WithMany(p => p.DateMedics)
            .HasForeignKey(d => d.DateDoctorId);
        }
    }
}