using JuanBosch.App.Models.Doctors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JuanBosch.App.Data.Configurations.Doctor
{
    public class DoctorEnsuranceConfiguration : IEntityTypeConfiguration<DoctorEnsurance>
    {
        public void Configure(EntityTypeBuilder<DoctorEnsurance> builder)
        {
            builder.ToTable("DoctorEnsurances");
            builder.HasKey(d => d.DoctorEnsuranceId);
            builder.Property(d => d.DoctorEnsuranceId)
            .ValueGeneratedOnAdd();

            builder.HasOne(d => d.DoctorMedic)
            .WithMany(m => m.DoctorEnsurances)
            .HasForeignKey(m => m.DoctorId);

            builder.HasOne(d => d.ArsEnsurance)
            .WithMany(a => a.DoctorEnsurances)
            .HasForeignKey(a => a.ArsEnsuranceId);

            builder.Property(d => d.MedicCode)
            .IsRequired()
            .HasMaxLength(25);
        }
    }
}