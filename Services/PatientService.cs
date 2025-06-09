using JuanBosch.App.Dtos.Patient;
using JuanBosch.App.Mapper;
using JuanBosch.App.Models.DataContext;
using JuanBosch.App.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace JuanBosch.App.Services
{
    public class PatientService : IPatientService
    {
        private readonly DataContext _context;
        public PatientService(DataContext context)
        {
            _context = context;
        }
        
        public async Task<List<PatientReadDto>> GetAllPatientsAsync()
        {
            return await _context.Patients.Select(p => PatientMapper.ToReadPatient(p)).ToListAsync();
        }

        public async Task<PatientReadDto> GetPatientByIdAsync(int id)
        {
            return await _context.Patients.Select(p => PatientMapper.ToReadPatient(p)).FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<PatientCreateDto> CreatePatientAsync(PatientCreateDto patient)
        {
            var newPatient = patient.ToCreatePatient();
            _context.Patients.Add(newPatient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<PatientReadDto> UpdatePatientAsync(int id, PatientReadDto patient)
        {
            var existingPatient = await _context.Patients.FindAsync(id);
            if (existingPatient == null)
            {
                throw new ArgumentNullException(nameof(existingPatient));
            }
            existingPatient.PatientName = patient.name;
            existingPatient.PatientLastName = patient.lastName;
            existingPatient.PatientIdCard = patient.idCard;
            existingPatient.PatientPassport = patient.passport;
            existingPatient.PatientPhone = patient.phone;
            existingPatient.PatientBirthDate = patient.dateOfBirth;
            existingPatient.PatientGender = patient.gender;
            existingPatient.PatientEmail = patient.email;
            existingPatient.AddressId = patient.addressId;
            // existingPatient.PatientDirection = patient.PatientDirection;
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<bool> DeletePatientAsync(int id)
        {
            var existingPatient = await _context.Patients.FindAsync(id);
            if (existingPatient == null)
            {
                throw new ArgumentNullException(nameof(existingPatient));
            }
            _context.Patients.Remove(existingPatient);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}