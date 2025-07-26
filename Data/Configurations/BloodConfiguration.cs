using JuanBosch.App.Models.Bloods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JuanBosch.App.Data.Configurations
{
    public class BloodConfiguration : IEntityTypeConfiguration<Blood>
    {
        public void Configure(EntityTypeBuilder<Blood> builder)
        {
            builder.ToTable("Blood");

            builder.HasKey(b => b.BloodId);
            builder.Property(b => b.BloodId)
            .ValueGeneratedOnAdd();

            builder.Property(b => b.BloodType)
            .IsRequired()
            .HasMaxLength(25);

            builder.Property(b => b.ConsentBlood)
            .IsRequired();
        }
    }
}