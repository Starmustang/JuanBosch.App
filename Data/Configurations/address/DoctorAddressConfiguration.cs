using JuanBosch.App.Models.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JuanBosch.App.Data.Configurations
{
    public class DoctorAddressConfiguration : IEntityTypeConfiguration<DoctorAddress>
    {
        public void Configure(EntityTypeBuilder<DoctorAddress> builder)
        {
            builder.ToTable("DoctorAddresses");

            builder.HasKey(da => da.DoctorAddressId);
            builder.Property(da => da.DoctorAddressId)
            .ValueGeneratedOnAdd();

            builder.Property(da => da.DoctorHouseNumber)
            .IsRequired();

            builder.Property(da => da.DoctorStreet)
            .IsRequired();

            builder.HasOne(da => da.Sector)
            .WithMany(se => se.DoctorAddresses)
            .HasForeignKey(se => se.SectorId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}