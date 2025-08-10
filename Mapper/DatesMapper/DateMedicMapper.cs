using JuanBosch.App.Dtos.Dates;
using JuanBosch.App.Models.Dates;

namespace JuanBosch.App.Mapper.DatesMapper
{
    public static class DateMedicMapper
    {
        // Create: DTO -> Entity
        public static DateMedic ToCreateDateMedic(this DateMedicCreateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new DateMedic
            {
                // Required navs are initialized with default! to satisfy C# 'required' members.
                // EF Core will populate these from the IDs when attached/tracked.
                Patient = default!,
                PatientId = dto.PatientId,
                Doctor = default!,
                DoctorId = dto.DoctorId,
                DateMedicDate = dto.DateMedicDate,
                HospitalMedicDate = dto.HospitalMedicDate,
                ConsultationType = default!,
                ConsultationTypeId = dto.ConsultationTypeId,
                DateDoctor = default!,
                DateDoctorId = dto.DateDoctorId
            };
        }

        // Read: Entity -> DTO
        public static DateMedicReadDto ToReadDateMedic(this DateMedic entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return new DateMedicReadDto
            {
                DateMedicId = entity.DateMedicId,
                PatientId = entity.PatientId,
                PatientName = entity.Patient?.PatientName ?? string.Empty,
                DoctorId = entity.DoctorId,
                DoctorName = entity.Doctor?.DoctorName ?? string.Empty,
                DateMedicDate = entity.DateMedicDate,
                HospitalMedicDate = entity.HospitalMedicDate,
                ConsultationTypeId = entity.ConsultationTypeId,
                DateDoctorId = entity.DateDoctorId
            };
        }

        // Update: DTO -> Entity (new instance)
        public static DateMedic ToUpdateDateMedic(this DateMedicUpdateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new DateMedic
            {
                DateMedicId = dto.DateMedicId,
                Patient = default!,
                PatientId = dto.PatientId,
                Doctor = default!,
                DoctorId = dto.DoctorId,
                DateMedicDate = dto.DateMedicDate,
                HospitalMedicDate = dto.HospitalMedicDate,
                ConsultationType = default!,
                ConsultationTypeId = dto.ConsultationTypeId,
                DateDoctor = default!,
                DateDoctorId = dto.DateDoctorId
            };
        }

        // Update in-place: apply DTO onto an existing entity
        public static void ApplyUpdate(this DateMedic entity, DateMedicUpdateDto dto)
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
            entity.DateMedicDate = dto.DateMedicDate;
            entity.HospitalMedicDate = dto.HospitalMedicDate;
            entity.ConsultationTypeId = dto.ConsultationTypeId;
            entity.DateDoctorId = dto.DateDoctorId;
        }
    }
}
