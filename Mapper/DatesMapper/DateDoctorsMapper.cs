using JuanBosch.App.Dtos.Dates;
using JuanBosch.App.Models.Dates;

namespace JuanBosch.App.Mapper.DatesMapper
{
    public static class DateDoctorsMapper
    {
        // Create: DTO -> Entity
        public static DateDoctor ToCreateDateDoctor(this DateDoctorCreateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new DateDoctor
            {
                DateDoctorSintoms = dto.DateDoctorSintoms,
                DateDoctorIndicatedAnalisis = dto.DateDoctorIndicatedAnalisis,
                DateDoctorTreatment = dto.DateDoctorTreatment,
                DateDoctorNotes = dto.DateDoctorNotes,
                DateDoctorNextDate = dto.DateDoctorNextDate,
                MedicEvaluationId = dto.MedicEvaluationId
            };
        }

        // Read: Entity -> DTO
        public static DateDoctorReadDto ToReadDateDoctor(this DateDoctor entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return new DateDoctorReadDto
            {
                DateDoctorId = entity.DateDoctorId,
                DateDoctorSintoms = entity.DateDoctorSintoms,
                DateDoctorIndicatedAnalisis = entity.DateDoctorIndicatedAnalisis,
                DateDoctorTreatment = entity.DateDoctorTreatment,
                DateDoctorNotes = entity.DateDoctorNotes,
                DateDoctorNextDate = entity.DateDoctorNextDate,
                MedicEvaluationId = entity.MedicEvaluationId
            };
        }

        // Update: DTO -> Entity (new instance)
        public static DateDoctor ToUpdateDateDoctor(this DateDoctorUpdateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new DateDoctor
            {
                DateDoctorId = dto.DateDoctorId,
                DateDoctorSintoms = dto.DateDoctorSintoms,
                DateDoctorIndicatedAnalisis = dto.DateDoctorIndicatedAnalisis,
                DateDoctorTreatment = dto.DateDoctorTreatment,
                DateDoctorNotes = dto.DateDoctorNotes,
                DateDoctorNextDate = dto.DateDoctorNextDate,
                MedicEvaluationId = dto.MedicEvaluationId
            };
        }

        // Update in-place: apply DTO onto an existing entity
        public static void ApplyUpdate(this DateDoctor entity, DateDoctorUpdateDto dto)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            entity.DateDoctorSintoms = dto.DateDoctorSintoms;
            entity.DateDoctorIndicatedAnalisis = dto.DateDoctorIndicatedAnalisis;
            entity.DateDoctorTreatment = dto.DateDoctorTreatment;
            entity.DateDoctorNotes = dto.DateDoctorNotes;
            entity.DateDoctorNextDate = dto.DateDoctorNextDate;
            entity.MedicEvaluationId = dto.MedicEvaluationId;
        }
    }
}
