using JuanBosch.App.Dtos.Patient;
using JuanBosch.App.Mapper;
using JuanBosch.App.Models;
using JuanBosch.App.Models.Persistence;
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
            var patients = await _context.Patients
                .Include(p => p.Blood)
                .Include(p => p.ArsPlans)
                .Include(p => p.PatientDirection)
                .ToListAsync();
            return patients.Select(p => PatientMapper.ToReadPatient(p)).ToList();
        }

        public async Task<PatientReadDto> GetPatientByIdAsync(int id)
        {
            var patient = await _context.Patients
                .Include(p => p.Blood)
                .Include(p => p.ArsPlans)
                .Include(p => p.PatientDirection)
                .FirstOrDefaultAsync(p => p.PatientId == id);

            if (patient == null)
            {
                return null;
            }

            return PatientMapper.ToReadPatient(patient);
        }

        public async Task<PatientCreateDto> CreatePatientAsync(PatientCreateDto patient)
        {
            var newPatient = patient.ToCreatePatient();
            _context.Patients.Add(newPatient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<PatientUpdateDto> UpdatePatientAsync(int id, PatientUpdateDto patient)
        {
            var existingPatient = await _context.Patients.FindAsync(id);
            if (existingPatient == null)
            {
                throw new ArgumentNullException(nameof(existingPatient));
            }
            existingPatient.PatientName = patient.PatientName;
            existingPatient.PatientLastName = patient.PatientLastName;
            existingPatient.PatientIdCard = patient.PatientIdCard;
            existingPatient.PatientPassport = patient.PatientPassport;
            existingPatient.PatientPhone = patient.PatientPhone;
            existingPatient.PatientBirthDate = patient.PatientBirthDate;
            existingPatient.PatientGender = patient.PatientGender;
            existingPatient.PatientEmail = patient.PatientEmail;
            
            if (patient.AddressId != null)
            {
                existingPatient.AddressId = patient.AddressId;
                
                if (existingPatient.PatientDirection == null)
                {
                    existingPatient.PatientDirection = new PatientDirection();
                }                                
            }
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