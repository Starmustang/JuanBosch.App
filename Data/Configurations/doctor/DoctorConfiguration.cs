using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JuanBosch.App.Models.Doctor;

namespace JuanBosch.App.Data.Configurations.Doctor
{
    public class DoctorConfiguration : IEntityTypeConfiguration<DoctorMedic>
    {
        public void Configure(EntityTypeBuilder<DoctorMedic> builder)
        {
            builder.ToTable("Doctors");
            builder.HasKey(d => d.DoctorId);
            builder.Property(d => d.DoctorId)
            .ValueGeneratedOnAdd();
            
            builder.Property(d => d.DoctorName)
            .IsRequired()
            .HasMaxLength(25);

            builder.Property(d => d.DoctorLastName)
            .IsRequired()
            .HasMaxLength(25);

            builder.Property(d => d.DoctorPhone)
            .IsRequired()
            .HasMaxLength(16);
            builder.Property(d => d.DoctorEmail)
            .IsRequired()
            .HasMaxLength(55);

            builder.Property(d => d.DoctorIdCard)
            .IsRequired()
            .HasMaxLength(13);

            builder.Property(d => d.DoctorPassport)
            .IsRequired()
            .HasMaxLength(25);

            builder.Property(d => d.DoctorSpeciality)
            .IsRequired()
            .HasMaxLength(35);

            builder.Property(d => d.DoctorAddressId)
            .IsRequired();

            builder.HasOne(d => d.DoctorAddress)
            .WithMany(a => a.Doctors)
            .HasForeignKey(d => d.DoctorAddressId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Property(d => d.DoctorExecatur)
            .IsRequired()
            .HasMaxLength(6);
        }
    }
}