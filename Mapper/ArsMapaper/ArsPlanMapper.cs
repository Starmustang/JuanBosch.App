using JuanBosch.App.Dtos.Ars;
using JuanBosch.App.Models.Ars;

namespace JuanBosch.App.Mapper.ArsMapaper
{
    public static class ArsPlanMapper
    {
        // Create: DTO -> Entity
        public static ArsPlans ToCreateArsPlan(this ArsPlanCreateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new ArsPlans
            {
                // Navigation will be set by EF via FK when appropriate
                ArsEnsurance = default!,
                AfiliationNumberArs = dto.AfiliationNumberArs,
                ArsPlansName = dto.ArsPlansName,
                CoveragePlanArs = dto.CoveragePlanArs,
                InternationalCoverage = dto.InternationalCoverage,
                IsPlanActive = dto.IsPlanActive,
                MaxLimitArs = dto.MaxLimitArs,
                ArsEnsuranceId = dto.ArsEnsuranceId
            };
        }

        // Read: Entity -> DTO
        public static ArsPlanReadDto ToReadArsPlan(this ArsPlans entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return new ArsPlanReadDto
            {
                ArsPlansId = entity.ArsPlansId,
                AfiliationNumberArs = entity.AfiliationNumberArs,
                ArsPlansName = entity.ArsPlansName,
                CoveragePlanArs = entity.CoveragePlanArs,
                InternationalCoverage = entity.InternationalCoverage,
                IsPlanActive = entity.IsPlanActive,
                MaxLimitArs = entity.MaxLimitArs,
                ArsEnsuranceId = entity.ArsEnsuranceId,
                EnsuranceName = entity.ArsEnsurance?.EnsuranceName ?? string.Empty
            };
        }

        // Update: DTO -> Entity (new instance)
        public static ArsPlans ToUpdateArsPlan(this ArsPlanUpdateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new ArsPlans
            {
                ArsPlansId = dto.ArsPlansId,
                ArsEnsurance = default!,
                AfiliationNumberArs = dto.AfiliationNumberArs,
                ArsPlansName = dto.ArsPlansName,
                CoveragePlanArs = dto.CoveragePlanArs,
                InternationalCoverage = dto.InternationalCoverage,
                IsPlanActive = dto.IsPlanActive,
                MaxLimitArs = dto.MaxLimitArs,
                ArsEnsuranceId = dto.ArsEnsuranceId
            };
        }

        // Update in-place on tracked entity
        public static void ApplyUpdate(this ArsPlans entity, ArsPlanUpdateDto dto)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            entity.AfiliationNumberArs = dto.AfiliationNumberArs;
            entity.ArsPlansName = dto.ArsPlansName;
            entity.CoveragePlanArs = dto.CoveragePlanArs;
            entity.InternationalCoverage = dto.InternationalCoverage;
            entity.IsPlanActive = dto.IsPlanActive;
            entity.MaxLimitArs = dto.MaxLimitArs;
        }
    }
}
