using JuanBosch.App.Models.MedicEvaluations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JuanBosch.App.Data.Configurations
{
    public class MedicEvaConfiguration : IEntityTypeConfiguration<MedicEvaluation>{
        public void Configure(EntityTypeBuilder<MedicEvaluation> builder)
        {
          builder.ToTable("MedicEvaluations");

          builder.HasKey(m => m.MedicEvaluationId);
          builder.Property(m => m.MedicEvaluationId)
          .ValueGeneratedOnAdd();

          builder.Property(m => m.WeightEva)
          .IsRequired();

          builder.Property(m => m.PresurreEva)
          .IsRequired();

          builder.Property(m => m.BreathingEva)
          .IsRequired();

          builder.Property(m => m.HeartRateEva)
          .IsRequired()
          .HasMaxLength(900);                    

          builder.Property(m => m.OtherInfoEva)
          .IsRequired()
          .HasMaxLength(900);


          builder.Property(m => m.HeightEva)
          .IsRequired()
          .HasMaxLength(20);

          builder.Property(m => m.PreviousSickNessEva)
          .IsRequired()
          .HasMaxLength(900);
          
        }
    }
}