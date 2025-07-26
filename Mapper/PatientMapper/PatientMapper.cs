using JuanBosch.App.Dtos.Patient;
using JuanBosch.App.Models;
using JuanBosch.App.Models.Patients;

namespace JuanBosch.App.Mapper
{
    public static class PatientMapper
    {
        public static Patient ToCreatePatient(this PatientCreateDto patientCreateDto)
        {
            if (patientCreateDto == null)
            {
                throw new ArgumentNullException(nameof(patientCreateDto));
            }
            return new Patient
            {
                PatientName = patientCreateDto.name,
                PatientLastName = patientCreateDto.lastName,
                PatientIdCard = patientCreateDto.idCard,
                PatientPassport = patientCreateDto.passport,
                PatientPhone = patientCreateDto.phone,
                PatientBirthDate = patientCreateDto.dateOfBirth,
                PatientGender = patientCreateDto.gender,
                PatientEmail = patientCreateDto.email,
                AddressId = patientCreateDto.Address?.AddressId,
                PatientDirection = patientCreateDto.Address != null ? new PatientDirection
                {
                    SectorId = patientCreateDto.Address.SectorId ?? 0,
                    MunicipalityId = patientCreateDto.Address.MunicipalityId ?? 0,
                    ProvinceId = patientCreateDto.Address.ProvinceId ?? 0,
                    CountryId = patientCreateDto.Address.CountryId ?? 0
                } : null
            };
        }
        public static PatientReadDto ToReadPatient(this Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }
            return new PatientReadDto
            {
                id = patient.PatientId,
                name = patient.PatientName,
                lastName = patient.PatientLastName,
                idCard = patient.PatientIdCard,
                passport = patient.PatientPassport,
                phone = patient.PatientPhone,
                dateOfBirth = patient.PatientBirthDate.Value,
                gender = patient.PatientGender,
                email = patient.PatientEmail,
                Address = new AddressDto
                {
                    AddressId = patient.AddressId,
                    SectorId = patient.PatientDirection?.SectorId,
                    MunicipalityId = patient.PatientDirection?.MunicipalityId,
                    ProvinceId = patient.PatientDirection?.ProvinceId,
                    CountryId = patient.PatientDirection?.CountryId
                }
            };
        }
    }
}