using JuanBosch.App.Models.Ars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JuanBosch.App.Data.Configurations
{
    public class ArsEnsuranceConfiguration : IEntityTypeConfiguration<ArsEnsurance>
    {
        public void Configure(EntityTypeBuilder<ArsEnsurance> builder)
        {
            builder.ToTable("ArsEnsurance");
            
            builder.HasKey(a => a.ArsEnsuranceId);
            builder.Property(a => a.ArsEnsuranceId)
            .ValueGeneratedOnAdd();

            builder.Property(a => a.EnsuranceName)
            .IsRequired()
            .HasMaxLength(25);

            builder.Property(a => a.EnsuranceDirection)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(a => a.EnsurancePhone)
            .IsRequired()
            .HasMaxLength(13);

            builder.Property(a => a.EnsurancePhone2)
            .HasMaxLength(13);

            builder.Property(a => a.EnsuranceFax)
            .HasMaxLength(13);

            builder.Property(a => a.EnsuranceEmail)
            .HasMaxLength(100);

            builder.Property(a => a.EnsuranceUpdateDate)
            .IsRequired();

            builder.Property(a => a.EnsuranceSchedule)
            .IsRequired();

            builder.HasMany(a => a.Plans)
            .WithOne(p => p.ArsEnsurance)
            .HasForeignKey(p => p.ArsEnsuranceId)
            .OnDelete(DeleteBehavior.Cascade);

            
        }
    }
}