using JuanBosch.App.Dtos.Doctors;
using JuanBosch.App.Models.Doctors;

namespace JuanBosch.App.Mapper.DoctorsMapper
{
    public static class DoctorEnsuranceMapper
    {
        // Create: DTO -> Entity
        public static DoctorEnsurance ToCreateDoctorEnsurance(this DoctorEnsurancesCreateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new DoctorEnsurance
            {
                DoctorId = dto.DoctorId,
                ArsEnsuranceId = dto.ArsEnsuranceId,
                MedicCode = dto.MedicCode
            };
        }

        // Read: Entity -> DTO
        public static DoctorEnsurancesReadDto ToReadDoctorEnsurance(this DoctorEnsurance entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return new DoctorEnsurancesReadDto
            {
                DoctorEnsuranceId = entity.DoctorEnsuranceId,
                DoctorId = entity.DoctorId,
                DoctorName = entity.DoctorMedic?.DoctorName ?? string.Empty,
                ArsEnsuranceId = entity.ArsEnsuranceId,
                EnsuranceName = entity.ArsEnsurance?.EnsuranceName ?? string.Empty,
                MedicCode = entity.MedicCode
            };
        }

        // Update: DTO -> Entity (new instance)
        public static DoctorEnsurance ToUpdateDoctorEnsurance(this DoctorEnsurancesUpdateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new DoctorEnsurance
            {
                DoctorEnsuranceId = dto.DoctorEnsuranceId,
                DoctorId = dto.DoctorId,
                ArsEnsuranceId = dto.ArsEnsuranceId,
                MedicCode = dto.MedicCode
            };
        }

        // Update in-place: apply DTO onto an existing entity
        public static void ApplyUpdate(this DoctorEnsurance entity, DoctorEnsurancesUpdateDto dto)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            entity.DoctorId = dto.DoctorId;
            entity.ArsEnsuranceId = dto.ArsEnsuranceId;
            entity.MedicCode = dto.MedicCode;
        }
    }
}
