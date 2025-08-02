using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JuanBosch.App.Models.Dates;

namespace JuanBosch.App.Data.Configurations.dates
{
    public class DateDoctorConfiguration : IEntityTypeConfiguration<DateDoctor>
    {
        public void Configure(EntityTypeBuilder<DateDoctor> builder)
        {
            builder.ToTable("DateDoctors");
            builder.HasKey(d => d.DateDoctorId);
            builder.Property(d => d.DateDoctorId)
            .ValueGeneratedOnAdd();

            builder.Property(d => d.DateDoctorSintoms)
            .IsRequired()
            .HasMaxLength(2000);

            builder.Property(d => d.DateDoctorIndicatedAnalisis)
            .IsRequired()
            .HasMaxLength(1000);

            builder.Property(d => d.DateDoctorTreatment)
            .IsRequired()
            .HasMaxLength(1000);

            builder.Property(d => d.DateDoctorNotes)
            .IsRequired()
            .HasMaxLength(1000);

            builder.Property(d => d.DateDoctorNextDate)
            .IsRequired();

            builder.HasMany(d => d.DateMedics)
            .WithOne(d => d.DateDoctor)
            .HasForeignKey(d => d.DateDoctorId);

           builder.HasOne(d => d.MedicEvaluation)
            .WithOne(p => p.DateDoctor)
            .HasForeignKey<DateDoctor>(d => d.MedicEvaluationId);
            
        }
    }
}