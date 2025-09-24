using JuanBosch.App.Dtos.Patient;
using JuanBosch.App.Models;
using JuanBosch.App.Models.Bloods;
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
                PatientName = patientCreateDto.PatientName,
                PatientLastName = patientCreateDto.PatientLastName,
                PatientIdCard = patientCreateDto.PatientIdCard,
                PatientPassport = patientCreateDto.PatientPassport,
                PatientPhone = patientCreateDto.PatientPhone,
                PatientBirthDate = patientCreateDto.PatientBirthDate,
                PatientGender = patientCreateDto.PatientGender,
                PatientEmail = patientCreateDto.PatientEmail,
                AddressId = patientCreateDto.AddressId,
                BloodId = patientCreateDto.BloodId,
                PatientEmergencieContact = patientCreateDto.PatientEmergencieContact,
                PatientFisRecord = patientCreateDto.PatientFirstRecord,
                ArsPlansId = patientCreateDto.ArsPlansId
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
                PatientId = patient.PatientId,
                PatientName = patient.PatientName,
                PatientLastName = patient.PatientLastName,
                PatientIdCard = patient.PatientIdCard,
                PatientPassport = patient.PatientPassport,
                PatientBirthDate = patient.PatientBirthDate,
                PatientGender = patient.PatientGender,
                PatientEmail = patient.PatientEmail,
                PatientPhone = patient.PatientPhone,
                ArsPlansId = patient.ArsPlansId,
                ArsPlansName = patient.ArsPlans?.ArsPlansName ?? string.Empty,
                AddressId = patient.AddressId,
                PatientEmergencieContact = patient.PatientEmergencieContact,
                PatientFirstRecord = patient.PatientFisRecord,
                BloodId = patient.BloodId,
                BloodType = patient.Blood?.BloodType ?? string.Empty
            };
        }
    }
}