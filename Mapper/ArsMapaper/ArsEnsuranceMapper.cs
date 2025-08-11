using JuanBosch.App.Dtos.Ars;
using JuanBosch.App.Models.Ars;

namespace JuanBosch.App.Mapper.ArsMapaper
{
    public static class ArsEnsuranceMapper
    {
        // Create: DTO -> Entity
        public static ArsEnsurance ToCreateArsEnsurance(this ArsEnsurancesCreateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new ArsEnsurance
            {
                EnsuranceName = dto.EnsuranceName,
                EnsuranceDirection = dto.EnsuranceDirection,
                EnsurancePhone = dto.EnsurancePhone,
                EnsurancePhone2 = dto.EnsurancePhone2,
                EnsuranceFax = dto.EnsuranceFax,
                EnsuranceEmail = dto.EnsuranceEmail,
                EnsuranceUpdateDate = dto.EnsuranceUpdateDate,
                EnsuranceSchedule = dto.EnsuranceSchedule
            };
        }

        // Read: Entity -> DTO
        public static ArsEnsurancesReadDto ToReadArsEnsurance(this ArsEnsurance entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return new ArsEnsurancesReadDto
            {
                ArsEnsuranceId = entity.ArsEnsuranceId,
                EnsuranceName = entity.EnsuranceName,
                EnsuranceDirection = entity.EnsuranceDirection,
                EnsurancePhone = entity.EnsurancePhone,
                EnsurancePhone2 = entity.EnsurancePhone2,
                EnsuranceFax = entity.EnsuranceFax,
                EnsuranceEmail = entity.EnsuranceEmail,
                EnsuranceUpdateDate = entity.EnsuranceUpdateDate,
                EnsuranceSchedule = entity.EnsuranceSchedule
            };
        }

        // Update: DTO -> Entity (new instance)
        public static ArsEnsurance ToUpdateArsEnsurance(this ArsEnsurancesUpdateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new ArsEnsurance
            {
                ArsEnsuranceId = dto.ArsEnsuranceId,
                EnsuranceName = dto.EnsuranceName,
                EnsuranceDirection = dto.EnsuranceDirection,
                EnsurancePhone = dto.EnsurancePhone,
                EnsurancePhone2 = dto.EnsurancePhone2,
                EnsuranceFax = dto.EnsuranceFax,
                EnsuranceEmail = dto.EnsuranceEmail,
                EnsuranceUpdateDate = dto.EnsuranceUpdateDate,
                EnsuranceSchedule = dto.EnsuranceSchedule
            };
        }

        // Update in-place on a tracked entity
        public static void ApplyUpdate(this ArsEnsurance entity, ArsEnsurancesUpdateDto dto)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            entity.EnsuranceName = dto.EnsuranceName;
            entity.EnsuranceDirection = dto.EnsuranceDirection;
            entity.EnsurancePhone = dto.EnsurancePhone;
            entity.EnsurancePhone2 = dto.EnsurancePhone2;
            entity.EnsuranceFax = dto.EnsuranceFax;
            entity.EnsuranceEmail = dto.EnsuranceEmail;
            entity.EnsuranceUpdateDate = dto.EnsuranceUpdateDate;
            entity.EnsuranceSchedule = dto.EnsuranceSchedule;
        }
    }
}
