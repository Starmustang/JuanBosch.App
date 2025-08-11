using JuanBosch.App.Dtos.Bloods;
using JuanBosch.App.Models.Bloods;

namespace JuanBosch.App.Mapper.Bloods
{
    public static class BloodsMapper
    {
        // Create: DTO -> Entity
        public static Blood ToCreateBlood(this BloodCreateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new Blood
            {
                BloodType = dto.BloodType,
                ConsentBlood = dto.ConsentBlood
            };
        }

        // Read: Entity -> DTO
        public static BloodReadDto ToReadBlood(this Blood entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return new BloodReadDto
            {
                BloodId = entity.BloodId,
                BloodType = entity.BloodType,
                ConsentBlood = entity.ConsentBlood
            };
        }

        // Update: DTO -> Entity (new instance)
        public static Blood ToUpdateBlood(this BloodUpdateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new Blood
            {
                BloodId = dto.BloodId,
                BloodType = dto.BloodType,
                ConsentBlood = dto.ConsentBlood
            };
        }

        // Update in-place: apply DTO onto an existing entity
        public static void ApplyUpdate(this Blood entity, BloodUpdateDto dto)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            entity.BloodType = dto.BloodType;
            entity.ConsentBlood = dto.ConsentBlood;
        }
    }
}
