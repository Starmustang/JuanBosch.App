using JuanBosch.App.Dtos.Patient;
using JuanBosch.App.Models;

namespace JuanBosch.App.Services.Interface
{
    public interface IPatientService
    {
        Task<List<PatientReadDto>> GetAllPatientsAsync();
        Task<PatientReadDto> GetPatientByIdAsync(int id);
        Task<PatientCreateDto> CreatePatientAsync(PatientCreateDto patient);
        Task<PatientUpdateDto> UpdatePatientAsync(int id, PatientUpdateDto patient);
        Task<bool> DeletePatientAsync(int id);
    }
}