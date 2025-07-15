using JuanBosch.App.Models.Ars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JuanBosch.App.Data.Configurations
{
    public class ArsPlansConfiguration : IEntityTypeConfiguration<ArsPlans>
    {
        public void Configure(EntityTypeBuilder<ArsPlans> builder)
        {
            builder.ToTable("ArsPlans");

            builder.HasKey(a => a.ArsPlansId);
            builder.Property(a => a.ArsPlansId)
            .ValueGeneratedOnAdd();

            builder.Property(a => a.AfiliationNumberArs)
            .IsRequired()
            .HasMaxLength(25);

            builder.Property(a => a.ArsPlansName)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(a => a.CoveragePlanArs)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(a => a.InternationalCoverage)
            .IsRequired();

            builder.Property(a => a.IsPlanActive)
            .IsRequired();

            builder.Property(a => a.MaxLimitArs)
            .HasMaxLength(25)
            .IsRequired();
        }
    }
}