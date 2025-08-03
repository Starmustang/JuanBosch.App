using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JuanBosch.App.Models.MedicRecords;

namespace JuanBosch.App.Data.Configurations.MedicRecords
{
    public class MedicRecordConfiguration : IEntityTypeConfiguration<MedicRecord>
    {
        public void Configure(EntityTypeBuilder<MedicRecord> builder)
        {
            builder.ToTable("MedicRecords");
            builder.HasKey(m => m.RecordId);
            builder.Property(m => m.RecordId)
            .ValueGeneratedOnAdd();

            builder.Property(m => m.FollowUpMedicRecord)
            .IsRequired()
            .HasMaxLength(2000);

            builder.Property(m => m.SignsMedicRecord)
            .IsRequired()
            .HasMaxLength(1000);

            builder.HasOne(m => m.Patient)
            .WithOne(p => p.MedicRecord)
            .HasForeignKey<MedicRecord>(m => m.PatientId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.DoctorsMedics)
            .WithMany(d => d.MedicRecords)
            .HasForeignKey(d => d.DoctorId);
        }
    }
}