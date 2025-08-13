using JuanBosch.App.Dtos.Doctors;
using JuanBosch.App.Models.Doctors;

namespace JuanBosch.App.Mapper.DoctorsMapper
{
    public static class DoctorMapper
    {
        // Create: DTO -> Entity
        public static DoctorMedic ToCreateDoctor(this DoctorCreateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new DoctorMedic
            {
                DoctorName = dto.DoctorName,
                DoctorLastName = dto.DoctorLastName,
                DoctorPhone = dto.DoctorPhone,
                DoctorEmail = dto.DoctorEmail,
                DoctorIdCard = dto.DoctorIdCard,
                DoctorPassport = dto.DoctorPassport,
                DoctorSpeciality = dto.DoctorSpeciality,
                DoctorAddressId = dto.DoctorAddressId,
                DoctorExecatur = dto.DoctorExecatur
            };
        }

        // Read: Entity -> DTO
        public static DoctorReadDto ToReadDoctor(this DoctorMedic entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return new DoctorReadDto
            {
                DoctorId = entity.DoctorId,
                DoctorName = entity.DoctorName,
                DoctorLastName = entity.DoctorLastName,
                DoctorPhone = entity.DoctorPhone,
                DoctorEmail = entity.DoctorEmail,
                DoctorIdCard = entity.DoctorIdCard,
                DoctorPassport = entity.DoctorPassport,
                DoctorSpeciality = entity.DoctorSpeciality,
                DoctorAddressId = entity.DoctorAddressId,
                DoctorHouseNumber = entity.DoctorAddress?.DoctorHouseNumber ?? string.Empty,
                DoctorStreet = entity.DoctorAddress?.DoctorStreet ?? string.Empty,
                DoctorExecatur = entity.DoctorExecatur
            };
        }

        // Update: DTO -> Entity (new instance)
        public static DoctorMedic ToUpdateDoctor(this DoctorUpdateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            return new DoctorMedic
            {
                DoctorId = dto.DoctorId,
                DoctorName = dto.DoctorName,
                DoctorLastName = dto.DoctorLastName,
                DoctorPhone = dto.DoctorPhone,
                DoctorEmail = dto.DoctorEmail,
                DoctorIdCard = dto.DoctorIdCard,
                DoctorPassport = dto.DoctorPassport,
                DoctorSpeciality = dto.DoctorSpeciality,
                DoctorAddressId = dto.DoctorAddressId,
                DoctorExecatur = dto.DoctorExecatur
            };
        }

        // Update in-place: apply DTO onto an existing entity
        public static void ApplyUpdate(this DoctorMedic entity, DoctorUpdateDto dto)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            entity.DoctorName = dto.DoctorName;
            entity.DoctorLastName = dto.DoctorLastName;
            entity.DoctorPhone = dto.DoctorPhone;
            entity.DoctorEmail = dto.DoctorEmail;
            entity.DoctorIdCard = dto.DoctorIdCard;
            entity.DoctorPassport = dto.DoctorPassport;
            entity.DoctorSpeciality = dto.DoctorSpeciality;
            entity.DoctorAddressId = dto.DoctorAddressId;
            entity.DoctorExecatur = dto.DoctorExecatur;
        }
    }
}
