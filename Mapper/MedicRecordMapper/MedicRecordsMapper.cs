using JuanBosch.App.Dtos.MedicRecordDtos;
using JuanBosch.App.Models.MedicRecords;

namespace JuanBosch.App.Mapper.MedicRecordMapper
{
    public static class MedicRecordsMapper
    {
        // Create: DTO -> Entity
        public static MedicRecord ToCreateMedicRecord(this MedicRecordCreateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new MedicRecord
            {
                // required navigation filled with default!; EF will set from FK when tracked
                Patient = default!,
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                FollowUpMedicRecord = dto.FollowUpMedicRecord,
                SignsMedicRecord = dto.SignsMedicRecord
            };
        }

        // Read: Entity -> DTO
        public static MedicRecordReadDto ToReadMedicRecord(this MedicRecord entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return new MedicRecordReadDto
            {
                RecordId = entity.RecordId,
                PatientName = entity.Patient?.PatientName,
                PatientId = entity.PatientId,
                DoctorId = entity.DoctorId,
                FollowUpMedicRecord = entity.FollowUpMedicRecord,
                SignsMedicRecord = entity.SignsMedicRecord
            };
        }

        // Update: DTO -> Entity (new instance)
        public static MedicRecord ToUpdateMedicRecord(this MedicRecordUpdateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new MedicRecord
            {
                RecordId = dto.RecordId,
                Patient = default!,
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                FollowUpMedicRecord = dto.FollowUpMedicRecord,
                SignsMedicRecord = dto.SignsMedicRecord
            };
        }

        // Update in-place: apply DTO onto an existing entity
        public static void ApplyUpdate(this MedicRecord entity, MedicRecordUpdateDto dto)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            entity.PatientId = dto.PatientId;
            entity.DoctorId = dto.DoctorId;
            entity.FollowUpMedicRecord = dto.FollowUpMedicRecord;
            entity.SignsMedicRecord = dto.SignsMedicRecord;
        }
    }
}
